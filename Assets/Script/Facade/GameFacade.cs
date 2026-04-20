using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFacade : MonoBehaviour
{
    private EnemyFactory factory;

    public TextMeshProUGUI levelText;
    public float minDistanceBetweenEnemies = 2f;

    private int enemiesAlive = 0;

    // 🔥 TRACK ALL ENEMIES CREATED BY FACTORY
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public void Initialize(GameObject enemyPrefab)
    {
        factory = new EnemyFactory(enemyPrefab, this);
    }

    public void RegisterEnemy(GameObject enemy)
    {
        spawnedEnemies.Add(enemy);
    }

    public void StartLevel(int level)
    {
        Debug.Log("LEVEL: " + level);

        if (levelText != null)
        {
            levelText.text = "Level " + level;
        }

        enemiesAlive = level;

        float[] rowsY = { 6f, 5f, 4f, 3f, 2f };
        List<Vector3> usedPositions = new List<Vector3>();

        for (int i = 0; i < level; i++)
        {
            Vector3 pos;
            bool validPosition;

            int safetyCounter = 0;

            do
            {
                float randomX = Random.Range(-8f, 8f);
                float randomY = rowsY[Random.Range(0, rowsY.Length)];

                pos = new Vector3(randomX, randomY, 0);

                validPosition = true;

                foreach (Vector3 usedPos in usedPositions)
                {
                    if (Vector3.Distance(pos, usedPos) < minDistanceBetweenEnemies)
                    {
                        validPosition = false;
                        break;
                    }
                }

                safetyCounter++;

                if (safetyCounter > 20)
                    break;

            } while (!validPosition);

            usedPositions.Add(pos);

            string type = (i % 2 == 0) ? "zigzag" : "horizontal";

            // 🔥 CREATE ENEMY USING FACTORY
            GameObject enemy = factory.CreateEnemy(type, pos);

            // 🔥 REGISTER ENEMY FOR TRACKING
            if (enemy != null)
            {
                spawnedEnemies.Add(enemy);
            }
        }
    }

    // 🔥 CALLED WHEN ENEMY DIES
    public void EnemyDied()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            Debug.Log("LEVEL COMPLETE");
        }
    }

    public int GetEnemiesAlive()
    {
        return enemiesAlive;
    }

    public void SetEnemiesAlive(int count)
    {
        enemiesAlive = count;
    }

    // 🔥 CLEAN RESET (NO FINDOBJECTS)
    public void ResetGame()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }

        spawnedEnemies.Clear();
        enemiesAlive = 0;
    }
}