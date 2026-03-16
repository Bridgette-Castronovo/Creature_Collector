using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public Material validMaterial;
    public Material invalidMaterial;

    private Camera cam;
    private bool isDragging = false;
    private Vector2Int currentCell;
    private Vector2Int previousCell;
    private bool hasBeenPlaced = false;
    private int layerMask;
    private Renderer rend;
    private Material defaultMaterial;

    void Start()
    {
        cam = Camera.main;
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;
        int cubeLayer = LayerMask.NameToLayer("Cube");
        layerMask = ~(1 << cubeLayer);
    }

    void OnMouseDown()
    {
        isDragging = true;
        if (hasBeenPlaced)
        {
            GridManager.Instance.UnregisterCell(previousCell);
        }
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Grid"))
            {
                currentCell = GridManager.Instance.WorldToGrid(hit.point);
                transform.position = GridManager.Instance.GridToWorld(currentCell);

                bool occupied = GridManager.Instance.IsCellOccupied(currentCell);
                rend.material = occupied ? invalidMaterial : validMaterial;
            }
        }
    }

    void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        if (!GridManager.Instance.IsCellOccupied(currentCell))
        {
            transform.position = GridManager.Instance.GridToWorld(currentCell);
            rend.material = defaultMaterial;
            GridManager.Instance.RegisterCell(currentCell, gameObject);
            previousCell = currentCell;
            hasBeenPlaced = true;
        }
        else
        {
            transform.position = GridManager.Instance.GridToWorld(previousCell);
            rend.material = defaultMaterial;
            GridManager.Instance.RegisterCell(previousCell, gameObject);
        }
    }
}