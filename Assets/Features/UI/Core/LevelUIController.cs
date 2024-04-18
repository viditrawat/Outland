using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIController : MonoBehaviour
{

    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject levelFailedPopup;
    [SerializeField] private PlayerController playerController;

    private void OnEnable()
    {
        playerController.playerDied += OpenLevelFailedPopup;
    }
    public void OpenPauseMenuPopup()
    {
        //Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }

    public void OpenLevelFailedPopup()
    {
        levelFailedPopup.SetActive(true);
    }


    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(DataProvider.Instance.CurrentLevel());
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

    private void OnDisable()
    {
        playerController.playerDied -= OpenLevelFailedPopup;
    }


}
