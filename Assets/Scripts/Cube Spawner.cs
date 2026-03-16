using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CubeSpawner : MonoBehaviour, IPointerDownHandler
{
    public GameObject cubePrefab;
    public Camera mainCamera;

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 spawnPos = mainCamera.ScreenToWorldPoint(new Vector3(
            eventData.position.x,
            eventData.position.y,
            10f
        ));

        GameObject newCube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);
        CubePlacer placer = newCube.GetComponent<CubePlacer>();
        if (placer != null)
        {
            placer.StartDragging();
        }
    }
}