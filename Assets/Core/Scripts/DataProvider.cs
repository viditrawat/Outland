using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class DataProvider : MonoBehaviour
{
    private static DataProvider instance;
    public static DataProvider Instance { get { return instance; } }

    private string currentLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    public void SetCurrentLevel(string _level) => currentLevel = _level;
    public string CurrentLevel()
    {
        return currentLevel;
    }

}
