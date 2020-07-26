using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public bool gameOver = false;

    void Start()
    {

    }

    void Update()
    {

       if(FindObjectOfType<Player>().currentHealth <= 0)
       {
            gameOver = true;
            gameOverUI.SetActive(true);
            return;
       }

    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene("PlayScene");
        gameOver = false;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
