using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{

    [SerializeField] private GameObject PauseMenu;
    public void OpenPauseMenuPopup()
    {
        //Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }
    public void ClosePauseMenuPopup()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    public void QuitLevel()
    {
        UiManager.instance.OpenMainMenu();
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
    }


}
