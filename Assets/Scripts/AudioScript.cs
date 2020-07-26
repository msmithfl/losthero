using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageSound();
    }

    public void ManageSound()
    {
        if (FindObjectOfType<PauseMenu>().GameIsPaused == true || FindObjectOfType<GameOver>().gameOver == true || FindObjectOfType<GameWon>().gameWon == true)
        {
            audioSource.Pause();
        }
        else
        {
            //audioSource.Play();
        }
    }
}
