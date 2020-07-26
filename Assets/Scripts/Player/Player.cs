using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    [SerializeField]
    private bool isHoldingKey = false;
    public Text healthUI;
    public Text expUI;
    public Text turnScriptUI;
    public Text turnCountUI;
    public GameObject keyImage;
    public ExperienceBar expBar;
    public int maxExp = 10;
    public int currentExp = 0;
    public int currentLvl = 1;
    public int turnCount = 1;
    

    void Start()
    {
        healthUI.text = "HP " + currentHealth + "/" + maxHealth;
        expUI.text = "LVL " + currentLvl;

        keyImage.SetActive(false);
        expBar.SetMaxExp(maxExp);

        turnScriptUI.text = " ";
        turnCount = 1;
        turnCountUI.text = "TURN " + turnCount;

    }

    void Update()
    {
        UpdateUI();
        UpdateTurnCount();
    }

    void UpdateTurnCount()
    {
        if (FindObjectOfType<PauseMenu>().GameIsPaused == false && FindObjectOfType<GameOver>().gameOver == false && FindObjectOfType<GameWon>().gameWon == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                turnCount++;
                turnCountUI.text = "TURN " + turnCount;
            }
        }
    }

    void UpdateUI()
    {
        healthUI.text = "HP " + currentHealth + "/" + maxHealth;

        if (isHoldingKey == false)
        {
            keyImage.SetActive(false);
        }

        //level up effects
        if (currentExp >= 10)
        {
            currentLvl++;
            expUI.text = "LVL " + currentLvl;            
            currentExp = 0;
            expBar.SetExp(0);
            maxHealth++;
            currentHealth += 2;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    

    //Collect functions for interacting with items/enemies
    //Connected with SpawnObject
    public void CollectHeart()
    {
        if(currentHealth >= maxHealth)
        {
            turnScriptUI.text = "HEALTH MAX";
            Debug.Log("Health Max!");
            return;
        }
        else
        {
            turnScriptUI.text = "HEALTH UP";
            currentHealth++;            
            Debug.Log("Heart Collected!");
        }       
    }

    public void CollectKey()
    {
        if (isHoldingKey == false)
        {
            turnScriptUI.text = "KEY COLLECTED";
            isHoldingKey = true;
            keyImage.SetActive(true);
            Debug.Log("Key Collected!");
        }
        else
        {
            turnScriptUI.text = "KEYS FULL";
            Debug.Log("Keys Full!");
            return;
        }
        
    }

    public void CollectEnemy()
    {
        turnScriptUI.text = "ENEMY ENCOUNTERED";
        currentHealth--;
        currentExp++;
        expBar.SetExp(currentExp);
        Debug.Log("Enemy Collected!");
    }

    public void CollectChest()
    {
        turnScriptUI.text = "CHEST COLLECTED";
        Debug.Log("Chest Collected!");
    }

    public void CollectDoor()
    {
        if (isHoldingKey)
        {
            GameObject[] currentObjects = GameObject.FindGameObjectsWithTag("SpawnObject");
            foreach (GameObject enemy in currentObjects)
                GameObject.Destroy(enemy);

            isHoldingKey = false;
            turnScriptUI.text = "DUNGEON CLEARED";
            currentLvl++;
            expUI.text = "LVL " + currentLvl;
            maxHealth++;
            Debug.Log("Door Opened!");
        }
        else
        {
            isHoldingKey = false;
            turnScriptUI.text = "DOOR WAS LOCKED";
            Debug.Log("Door Was Locked!");            
        }
    }
}
