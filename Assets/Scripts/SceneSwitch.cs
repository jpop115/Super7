using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    // Use this for initialization


    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
