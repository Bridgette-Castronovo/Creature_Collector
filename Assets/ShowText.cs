using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject textObject;

    public void ShowTheText()
    {
        textObject.SetActive(true);
    }
}