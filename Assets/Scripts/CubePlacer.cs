using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public Material validMaterial;
    public Material invalidMaterial;
    public AudioClip dropSound;
    public AudioClip dragSound;
    private Camera cam;
    private bool isDragging = false;
    private Vector2Int currentCell;
    private Vector2Int previousCell;
    private bool hasBeenPlaced = false;
    private int layerMask;
    private Renderer[] renderers;
    private Material[] defaultMaterials;

    public int habitatCounter;

    void Awake()
    {
        cam = Camera.main;
        renderers = GetComponentsInChildren<Renderer>();

        // Save each child's original material
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

    public void StartDragging()
    {
        isDragging = true;
        GridManager.Instance.AddHabitat();
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
                transform.position = GridManager.Instance.GridToWorld(currentCell);

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
            transform.position = GridManager.Instance.GridToWorld(currentCell);
            ResetMaterials();
            GridManager.Instance.RegisterCell(currentCell, gameObject);
            previousCell = currentCell;
            hasBeenPlaced = true;
            PlayDropSound();
        }
        else if (hasBeenPlaced)
        {
            transform.position = GridManager.Instance.GridToWorld(previousCell);
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