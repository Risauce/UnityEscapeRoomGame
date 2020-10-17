using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    public Canvas settingsCanvas;
    public Canvas creditsCanvas;
    public Canvas gameCanvas;
    public Canvas winCanvas;
    void Start()
    {
        creditsCanvas.enabled = false;
        settingsCanvas.enabled = false;
        gameCanvas.enabled = false;

    }

    // Update is called once per frame
    public void showSettingsCanvas()
    {
        settingsCanvas.enabled = true;
    
    }

    public void hideSettingsCanvas()
    {
        settingsCanvas.enabled = false;
    }

    public void showCreditsCanvas()
    {
        creditsCanvas.enabled = true;
    }

    public void hideCreditsCanvas()
    {
        creditsCanvas.enabled = false;
    }

    public void showGameCanvas()
    {
        gameCanvas.enabled = true;
    }

    public void hideaGameCanvas()
    {
        gameCanvas.enabled = false;
    }


    public void loadWizard() {
        SceneManager.LoadScene("WizardTower", LoadSceneMode.Single);
    }

    public void loadDungeon()
    {
        SceneManager.LoadScene("Dungeon", LoadSceneMode.Single);
    }
    
}
