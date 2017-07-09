using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    private Scene scene;
    private AudioSource audioSource;

    // Use this for initialization


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }   

    public void StartGame()
    {
        audioSource.Play();
        Invoke("LoadNextScene", 3);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextScene()
    {
        scene = SceneManager.GetActiveScene();
        int sceneNumber = scene.buildIndex;
        SceneManager.LoadScene(sceneNumber + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
