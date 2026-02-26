using UnityEngine;
using UnityEngine.SceneManagement;

public class LiveFeedToggle : MonoBehaviour
{
    public void LoadMapView()
    {
        SceneManager.LoadScene("HabitatView");
    }
}