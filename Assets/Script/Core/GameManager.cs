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
    public GameObject player;



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameFacade.Initialize(enemyPrefab);
    }

    // 🔥 START GAME
    public void StartGame()
    {
        level = 1;

        UpdateLevelUI();

        SpawnNextLevel();

        //player.SetState(new AliveState());
        player.SetActive(true);
        if (player != null)
        {
            PlayerHealth ph = player.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.ResetPlayer();
            }
        }

        if (PlayerBulletPool.Instance != null)
            PlayerBulletPool.Instance.ResetPool();

        if (EnemyBulletPool.Instance != null)
            EnemyBulletPool.Instance.ResetPool();
    }

    void SpawnNextLevel()
    {
        if (gameFacade != null)
            gameFacade.StartLevel(level);
    }

    // 🔥 CALLED BY ENEMY WHEN IT DIES
    public void EnemyDied()
    {
        if (gameFacade != null)
        {
            gameFacade.EnemyDied();

            // 🔥 CHECK IF LEVEL COMPLETE
            if (gameFacade.GetEnemiesAlive() <= 0)
            {
                level++;

                UpdateLevelUI();

                Invoke(nameof(SpawnNextLevel), 1.5f);
            }
        }
    }

    void UpdateLevelUI()
    {
        if (levelText != null)
            levelText.text = "Level: " + level;
    }
}