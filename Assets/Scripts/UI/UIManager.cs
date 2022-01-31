using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public void ResetLevel()
    {
        if (!LevelManager.Instance)
        {
            Debug.LogWarning("No LevelManagers found in the scene!");
            return;
        }

        LevelManager.Instance.ResetLevel();
    }
}
