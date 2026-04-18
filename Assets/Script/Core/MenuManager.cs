using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject recordPanel;
    public GameObject gameUI;
    public GameManager gameManager;
    public GameTimer timer;

    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);

        gameManager.StartGame();
        timer.StartTimer();
    }

    public void ShowRecords()
    {
        recordPanel.SetActive(true);
    }

    public void CloseRecords()
    {
        recordPanel.SetActive(false);
    }
}
