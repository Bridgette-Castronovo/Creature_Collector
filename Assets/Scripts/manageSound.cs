using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class manageSound : MonoBehaviour
{
    public AudioClip officeBGM;
    public AudioClip outsideBGM;
    public AudioClip currMusic;
    private AudioClip prevMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Scene currentScene = SceneManager.GetActiveScene ();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

		if (sceneName == "StoreScene" || (sceneName == "MapScene") || (sceneName == "HabitatView")) 
		{
			currMusic = outsideBGM;
		}
		else
		{
			currMusic = officeBGM;
		}

    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        if (sceneName == "StoreScene" || (sceneName == "MapScene") || (sceneName == "HabitatView")) 
		{
			prevMusic = currMusic;
            currMusic = outsideBGM;
		}
		else
		{
            prevMusic = currMusic;
			currMusic = officeBGM;
		}
        
        if (currMusic == officeBGM && !audioSource.isPlaying) 
        {
            audioSource.PlayOneShot(officeBGM);
        }
        else if (currMusic == outsideBGM && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(outsideBGM);
        }
        if (audioSource.isPlaying && prevMusic != currMusic)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(currMusic);
            
        }
    }
}