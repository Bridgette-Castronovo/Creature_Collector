using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public Material validMaterial;
    public Material invalidMaterial;
    public AudioClip dropSound;
    public AudioClip dragSound; // Assign in Inspector

    private Camera cam;
    private bool isDragging = false;
    private Vector2Int currentCell;
    private Vector2Int previousCell;
    private bool hasBeenPlaced = false;
    private int layerMask;
    private Renderer rend;
    private Material defaultMaterial;

    void Awake()
    {
        cam = Camera.main;
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;
        int cubeLayer = LayerMask.NameToLayer("Cube");
        layerMask = ~(1 << cubeLayer);
    }

    public void StartDragging()
    {
        isDragging = true;
        PlayDragSound(); // For programmatic drag starts
    }

    void OnMouseDown()
    {
        isDragging = true;
        PlayDragSound(); // Plays when player clicks and starts dragging
        if (hasBeenPlaced)
        {
            GridManager.Instance.UnregisterCell(previousCell);
        }
    }

    void Update()
    {
        if (isDragging)
        {
            HandleDrag();
            if (Input.GetMouseButtonUp(0))
            {
                HandleRelease();
            }
        }
    }

    void OnMouseDrag()
    {
        HandleDrag();
    }

    void OnMouseUp()
    {
        HandleRelease();
    }

    void HandleDrag()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Grid"))
            {
                currentCell = GridManager.Instance.WorldToGrid(hit.point);
                currentCell = GridManager.Instance.ClampToGrid(currentCell);
                transform.position = GridManager.Instance.GridToWorld(currentCell);
                bool occupied = GridManager.Instance.IsCellOccupied(currentCell);
                rend.material = occupied ? invalidMaterial : validMaterial;
            }
        }
    }

    void HandleRelease()
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
            PlayDropSound();
        }
        else if (hasBeenPlaced)
        {
            transform.position = GridManager.Instance.GridToWorld(previousCell);
            rend.material = defaultMaterial;
            GridManager.Instance.RegisterCell(previousCell, gameObject);
            PlayDropSound();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void PlayDragSound()
    {
        if (dragSound != null)
            AudioSource.PlayClipAtPoint(dragSound, transform.position);
    }

    void PlayDropSound()
    {
        if (dropSound != null)
            AudioSource.PlayClipAtPoint(dropSound, transform.position);
    }
}