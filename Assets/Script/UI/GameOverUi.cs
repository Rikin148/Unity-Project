using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timeText;

    public GameTimer timer;

    public void ShowGameOver(int level)
    {
        Debug.Log("GAME OVER TRIGGERED");
        panel.SetActive(true);

        float time = timer.GetTime();

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        levelText.text = "Level: " + level;
        timeText.text = $"Time: {minutes:00}:{seconds:00}";
    }
}