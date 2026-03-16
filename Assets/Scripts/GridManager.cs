using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public float cellSize = 1f;
    public Vector3 gridOrigin = Vector3.zero;

    private Dictionary<Vector2Int, GameObject> occupiedCells = new();

    void Awake()
    {
        Instance = this;
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