using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject enemyPrefab;

    public int level = 1;

    public TextMeshProUGUI levelText;

    public GameFacade gameFacade;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // ✅ ONLY initialize, DO NOT start game
        gameFacade.Initialize(enemyPrefab);
    }

    // 🔥 NEW FUNCTION (called from Menu)
    public void StartGame()
    {
        level = 1;
        SpawnNextLevel();
    }

    void SpawnNextLevel()
    {
        gameFacade.StartLevel(level);
    }

    public void EnemyDied()
    {
        int enemiesAlive = gameFacade.GetEnemiesAlive();

        gameFacade.OnEnemyDied(ref level, ref enemiesAlive, this);

        gameFacade.SetEnemiesAlive(enemiesAlive);
    }
}