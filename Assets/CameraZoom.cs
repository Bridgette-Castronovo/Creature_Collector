using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Header("Zoom Settings")]
    public Vector3 targetPosition = new Vector3(0f, 5f, -10f); // Where to zoom TO
    public float zoomDuration = 1.5f;                           // How long the zoom takes
    public AnimationCurve zoomCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isZoomed = false;
    private Coroutine zoomCoroutine;

    void Start()
    {
        // Save the camera's starting position
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void OnZoomButtonClicked()
    {
        if (zoomCoroutine != null) StopCoroutine(zoomCoroutine);

        if (!isZoomed)
            zoomCoroutine = StartCoroutine(ZoomTo(targetPosition));
        else
            zoomCoroutine = StartCoroutine(ZoomTo(originalPosition)); // Zoom back out

        isZoomed = !isZoomed;
    }

    private System.Collections.IEnumerator ZoomTo(Vector3 destination)
    {
        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            float t = zoomCurve.Evaluate(elapsed / zoomDuration);
            transform.position = Vector3.Lerp(startPos, destination, t);
            yield return null;
        }

        transform.position = destination;
    }
}