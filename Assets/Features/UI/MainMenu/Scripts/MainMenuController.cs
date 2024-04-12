using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelection;
    public void OpenLevelOne()
    {
        AudioManager.Instance.PlayCickSound();
        UiManager.instance.OpenScene("Level1");
    }


    public void StartGame()
    {
        mainMenu.SetActive(false);
        AudioManager.Instance.PlayCickSound();
        levelSelection.SetActive(true);
    }

   public void QuitGame()
    {
        AudioManager.Instance.PlayCickSound();
        Application.Quit();
    }
}
