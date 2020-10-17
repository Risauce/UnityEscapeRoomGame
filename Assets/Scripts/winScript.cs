using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas winCanvas;
    void Start()
    {
        winCanvas.enabled = true;
    }

    public void loadMainMenu()
    {
        print("works");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
