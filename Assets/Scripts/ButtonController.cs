using UnityEngine;

public class EmailButtonController : MonoBehaviour
{
    public GameObject emailPanel;

    public void OnEmailButtonClicked()
    {
        Debug.Log("Email button clicked!");
        emailPanel.SetActive(true);
    }
}