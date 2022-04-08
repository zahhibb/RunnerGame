using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseCanvas;
    public GameObject settingsMenu;

    public string mainMenuScene;

    public bool paused = false;
    bool settingsOpen = false;

    void Start()
    {
        settingsMenu.SetActive(false);
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        paused = !paused;

        if (paused)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        PauseGame();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettings()
    {
        settingsOpen = !settingsOpen;
        if (settingsOpen)
        {
            settingsMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(false);
        }
    }

}
