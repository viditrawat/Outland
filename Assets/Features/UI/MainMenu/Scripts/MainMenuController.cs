using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OpenLevelOne()
    {
        UiManager.instance.OpenScene("Level1");
    }

   public void QuitGame()
    {
        Application.Quit();
    }
}
