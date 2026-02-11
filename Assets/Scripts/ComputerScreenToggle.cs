using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerScreenToggle : MonoBehaviour
{
    public void LoadComputerScreenView()
    {
        SceneManager.LoadScene("Computer Scene");
    }
}
