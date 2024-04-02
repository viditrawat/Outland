using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OpenLevelOne()
    {
        AudioManager.Instance.PlayCickSound();
        UiManager.instance.OpenScene("Level1");
    }

   public void QuitGame()
    {
        AudioManager.Instance.PlayCickSound();
        Application.Quit();
    }
}
