using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public Material validMaterial;
    public Material invalidMaterial;
    public AudioClip dropSound;
    public AudioClip dragSound;
    public float yOffset = 0f;
    private Camera cam;
    private bool isDragging = false;
    private Vector2Int currentCell;
    private Vector2Int previousCell;
    private bool hasBeenPlaced = false;
    private int layerMask;
    private Renderer[] renderers;
    private Material[] defaultMaterials;

    void Awake()
    {
        cam = Camera.main;
        renderers = GetComponentsInChildren<Renderer>();

        defaultMaterials = new Material[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            defaultMaterials[i] = renderers[i].material;
        }

        int cubeLayer = LayerMask.NameToLayer("Cube");
        layerMask = ~(1 << cubeLayer);
    }

    void SetMaterial(Material mat)
    {
        foreach (Renderer r in renderers)
        {
            r.material = mat;
        }
    }

    void ResetMaterials()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = defaultMaterials[i];
        }
    }

    Vector3 GetPlacementPosition(Vector2Int cell)
    {
        return GridManager.Instance.GridToWorld(cell) + Vector3.up * yOffset;
    }

    public void StartDragging()
    {
        isDragging = true;
        PlayDragSound();
    }

    void OnMouseDown()
    {
        isDragging = true;
        PlayDragSound();
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
                transform.position = GetPlacementPosition(currentCell);

                bool occupied = GridManager.Instance.IsCellOccupied(currentCell);
                SetMaterial(occupied ? invalidMaterial : validMaterial);
            }
        }
    }

    void HandleRelease()
    {
        if (!isDragging) return;
        isDragging = false;

        if (!GridManager.Instance.IsCellOccupied(currentCell))
        {
            transform.position = GetPlacementPosition(currentCell);
            ResetMaterials();
            GridManager.Instance.RegisterCell(currentCell, gameObject);
            previousCell = currentCell;
            hasBeenPlaced = true;
            PlayDropSound();
        }
        else if (hasBeenPlaced)
        {
            transform.position = GetPlacementPosition(previousCell);
            ResetMaterials();
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