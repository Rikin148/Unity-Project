using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject recordPanel;
    public GameObject gameUI;
    public GameObject howToPlayPanel;
    public GameObject gameOverPanel;

    public GameManager gameManager;
    public GameTimer timer;
    public GameObject player;
    public GameFacade gameFacade;

    public RecordUI recordUI;

    // 🔥 START GAME (FULL RESET)
    public void StartGame()
    {
        Time.timeScale = 1f;

        // UI
        mainMenu.SetActive(false);
        recordPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameUI.SetActive(true);

        // 🔥 RESET FACTORY SYSTEM
        if (gameFacade != null)
            gameFacade.ResetGame();

        // 🔥 RESET TIMER
        if (timer != null)
        {
            timer.StartTimer();
        }

        // 🔥 START GAME LOGIC
        if (gameManager != null)
        {
            gameManager.StartGame();
        }


    }

    // 🔥 RECORDS
    public void DisplayRecords()
    {
        recordPanel.SetActive(true);

        if (recordUI != null)
            recordUI.ShowRecords();
    }

    public void CloseRecords()
    {
        recordPanel.SetActive(false);
    }

    // 🔥 HOW TO PLAY
    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }

    // 🔥 BACK TO MENU (NO RESET HERE)
    public void BackToMenu()
    {
        Time.timeScale = 1f;

        gameUI.SetActive(false);
        recordPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        mainMenu.SetActive(true);

        // stop timer only
        if (timer != null)
            timer.StopTimer();
    }
}