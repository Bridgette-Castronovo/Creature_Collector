using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public float cellSize = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public int habitatCounter;
    public TextMeshProUGUI habitatText;


    private Dictionary<Vector2Int, GameObject> occupiedCells = new();

    void Awake()
    {
        Instance = this;
    }
    public void AddHabitat()
    {
        habitatCounter++;
        Debug.Log("habitat counter updated");
        habitatText.text = "x" + habitatCounter;
    }
    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        int x = Mathf.RoundToInt((worldPos.x - gridOrigin.x) / cellSize);
        int z = Mathf.RoundToInt((worldPos.z - gridOrigin.z) / cellSize);
        return new Vector2Int(x, z);
    }

    public Vector3 GridToWorld(Vector2Int cell)
    {
        return new Vector3(
            cell.x * cellSize + gridOrigin.x,
            gridOrigin.y + cellSize * 0.5f,
            cell.y * cellSize + gridOrigin.z
        );
    }

    public Vector2Int ClampToGrid(Vector2Int cell)
    {
        int halfWidth = gridWidth / 2;
        int halfHeight = gridHeight / 2;
        int clampedX = Mathf.Clamp(cell.x, -halfWidth, halfWidth);
        int clampedZ = Mathf.Clamp(cell.y, -halfHeight, halfHeight);
        return new Vector2Int(clampedX, clampedZ);
    }

    public bool IsCellOccupied(Vector2Int cell)
    {
        return occupiedCells.ContainsKey(cell);
    }

    public void RegisterCell(Vector2Int cell, GameObject cube)
    {
        occupiedCells[cell] = cube;
    }

    public void UnregisterCell(Vector2Int cell)
    {
        occupiedCells.Remove(cell);
    }
}