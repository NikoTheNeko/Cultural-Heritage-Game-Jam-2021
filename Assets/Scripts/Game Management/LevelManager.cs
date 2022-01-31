using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Player References")]
    public PlayerController player1;
    public PlayerController player2;

    public Vector2 player1Spawn;
    public Vector2 player2Spawn;

    public void ResetLevel()
    {
        player1.transform.position = player1Spawn;
        player2.transform.position = player2Spawn;
    }
}
