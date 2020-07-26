using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene("PlayScene");
        GameIsPaused = false;

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }

}
