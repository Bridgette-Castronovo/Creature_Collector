using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void OpenEmailScene()
    {
        SceneManager.LoadScene("Emails");
    }
}