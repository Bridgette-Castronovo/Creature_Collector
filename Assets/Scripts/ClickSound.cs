using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = left click
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}