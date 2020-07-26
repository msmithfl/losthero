using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameMode;

public class SpawnObject : MonoBehaviour
{
    public int objectID;
    public double spawnRate;
    public char row;
    public int index;
    public virtual bool DidSpawn(int roll)
    {
        return spawnRate * 100 >= roll;
    }
    void Start()
    {
    }
    void Update()
    {
        MoveObjects();
    }
    void MoveObjects()
    {
        if (FindObjectOfType<PauseMenu>().GameIsPaused == true || FindObjectOfType<GameOver>().gameOver == true || FindObjectOfType<GameWon>().gameWon == true)
        {
            return;
        }
        else
        {

            switch (GameMode.current)
            {
                case GameMode.Type.AllPaths:
                    allPathsMove();
                    break;
                case GameMode.Type.ThreePaths:
                    threePathsMove();
                    break;
                case GameMode.Type.SinglePath:
                    singlePathMove();
                    break;
            }
        }
    }

    private void allPathsMove()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            index -= 1;
            updatePosition();
        }
    }
    private void singlePathMove()
    {
        if (
            (Input.GetKeyDown(KeyCode.W) && row == 'T') ||
            (Input.GetKeyDown(KeyCode.A) && row == 'L') ||
            (Input.GetKeyDown(KeyCode.S) && row == 'B') ||
            (Input.GetKeyDown(KeyCode.D) && row == 'R')
        )
        {
            index -= 1;
            updatePosition();
        }
    }

    

        private void threePathsMove()
        {
            if (
                (Input.GetKeyDown(KeyCode.W) && row != 'B') ||
                (Input.GetKeyDown(KeyCode.A) && row != 'R') ||
                (Input.GetKeyDown(KeyCode.S) && row != 'T') ||
                (Input.GetKeyDown(KeyCode.D) && row != 'L')
            )
            {
                index -= 1;
                updatePosition();
            }
        }

        private void updatePosition()
        {
            Vector3 spawnOffset = new Vector3(0, 0.02f, 0);

            if (index >= 0)
            {
                transform.position = GameObject.Find("PlaceBubble" + row.ToString() + index.ToString()).transform.position + spawnOffset;
            }
            else
            {
                collision();
            }
        }
        private void collision()
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            switch (objectID)
            {
                case 0:
                    player.CollectHeart();
                    break;
                case 1:
                    player.CollectKey();
                    break;
                case 2:
                    player.CollectEnemy();
                    break;
                case 3:
                    player.CollectChest();
                    break;
                case 4:
                    player.CollectDoor();
                    break;
                default:
                    //Debug.Log("Default Value");
                    break;
            }
            Destroy(this.gameObject);
        }
    }
