using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int _leftPlayerScore
    public static int leftPlayerScore = 0;
    public static int rightPlayerScore = 0;

    public static EventHandler ScoreUpdated;
    void Start()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
    }

}    


