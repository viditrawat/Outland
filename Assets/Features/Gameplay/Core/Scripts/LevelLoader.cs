using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private TextMeshProUGUI levelText;
    private void Start()
    {

        if (LevelManager.Instance.GetLevelStatus(levelName) == LevelStatus.Locked)
        {
            levelText.text = "Locked";
        }
        if (LevelManager.Instance.GetLevelStatus(levelName) == LevelStatus.Unlocked)
        {
            levelText.text = levelName;
        }
    }

    public void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level is locked");
                break;

            case LevelStatus.Unlocked:
                AudioManager.Instance.Play(Sounds.ButtonClick);
                DataProvider.Instance.SetCurrentLevel(levelName);
                SceneManager.LoadScene(levelName);
                break;

            case LevelStatus.Completed:
                AudioManager.Instance.Play(Sounds.ButtonClick);
                DataProvider.Instance.SetCurrentLevel(levelName);
                SceneManager.LoadScene(levelName);
                break;

        }


    }
}
