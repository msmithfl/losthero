using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public enum Type
    {
        SinglePath,
        ThreePaths,
        AllPaths
    }

    public static Type current = Type.SinglePath;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}