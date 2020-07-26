using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{

    public GameObject gameWonUI;
    public bool gameWon = false;
    public Text turnsUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int turnCount = FindObjectOfType<Player>().turnCount;

        if (FindObjectOfType<Player>().currentLvl == 10)
        {
            gameWon = true;
            turnsUI.text = "You escaped in " + turnCount + " turns";
            gameWonUI.SetActive(true);
            return;
        }
    }
}
