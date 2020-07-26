using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnList;
    public GameObject objectContainer;

    void Start()
    {
    }

    void Update()
    {
        SpawnObjects();        
    }

    void SpawnObjects()
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
                    SpawnAll();
                    break;
                case GameMode.Type.ThreePaths:
                    SpawnThree();
                    break;
                case GameMode.Type.SinglePath:
                    SpawnSingle();
                    break;
            }
        }
        
    }

    void SpawnAll()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            
            Spawn("PlaceBubbleT2", 'T', 2);
            Spawn("PlaceBubbleB2", 'B', 2);
            Spawn("PlaceBubbleL2", 'L', 2);
            Spawn("PlaceBubbleR2", 'R', 2);
        }
    }

    void SpawnThree()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Spawn("PlaceBubbleT2", 'T', 2);
            Spawn("PlaceBubbleL2", 'L', 2);
            Spawn("PlaceBubbleR2", 'R', 2);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Spawn("PlaceBubbleT2", 'T', 2);
            Spawn("PlaceBubbleL2", 'L', 2);
            Spawn("PlaceBubbleB2", 'B', 2);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Spawn("PlaceBubbleL2", 'L', 2);
            Spawn("PlaceBubbleB2", 'B', 2);
            Spawn("PlaceBubbleR2", 'R', 2);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Spawn("PlaceBubbleT2", 'T', 2);
            Spawn("PlaceBubbleR2", 'R', 2);
            Spawn("PlaceBubbleB2", 'B', 2);
        }
    }

    void SpawnSingle()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Spawn("PlaceBubbleT2", 'T', 2);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Spawn("PlaceBubbleL2", 'L', 2);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Spawn("PlaceBubbleB2", 'B', 2);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Spawn("PlaceBubbleR2", 'R', 2);
        }
    }


    void Spawn(string label, char row, int index)
    {
        Vector3 spawnOffset = new Vector3(0, 0.02f, 0);

        GameObject newObject = Instantiate(
            getRandomSpawn(),
            GameObject.Find(label).transform.position + spawnOffset,
            Quaternion.identity
        );
        SpawnObject spawnObject = newObject.GetComponent<SpawnObject>();
        spawnObject.row = row;
        spawnObject.index = index;

    
    newObject.transform.parent = objectContainer.transform;
    }
    

    GameObject getRandomSpawn()
    {
        int roll = Random.Range(0, 100);

        List<GameObject> candidates = new List<GameObject>();
        foreach (GameObject spawn in spawnList) {
            if (spawn.GetComponent<SpawnObject>().DidSpawn(roll)) {
                candidates.Add(spawn);
            }
        }

        return candidates[Random.Range(0, candidates.Count)];
    }
}
