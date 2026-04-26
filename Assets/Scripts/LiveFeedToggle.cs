using UnityEngine;
using UnityEngine.SceneManagement;

public class LiveFeedToggle : MonoBehaviour
{
    public void LoadMapView()
    {
        Debug.Log(PlayerManager.Instance.habitats.Count);
        Debug.Log(PlayerManager.Instance.habitats[0].animal1 != null);
        SceneManager.LoadScene("HabitatView");
    }
}