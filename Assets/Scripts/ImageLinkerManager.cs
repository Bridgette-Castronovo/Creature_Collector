using UnityEngine;
using UnityEngine.UI;

public class ImageLinkerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject targetImageGameObject; // Reference to the entire GameObject to show/hide

    // Function called by the button's OnClick event
    public void ToggleTargetImageVisibility()
    {
        if (targetImageGameObject != null)
        {
            // Toggle the active state of the target GameObject
            targetImageGameObject.SetActive(!targetImageGameObject.activeSelf);
        }
    }
}
