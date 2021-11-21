using System;
using DG.Tweening;
using Enemies;
using Levels;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private ScrollingBackground _background;

    private void Awake()
    {
        _background.Scroll(true);
    }

    private void OnEnable()
    {
        Level.OnLevelSectionsCompleted += LevelCompleted;
    }

    private void OnDisable()
    {
        Level.OnLevelSectionsCompleted -= LevelCompleted;
    }

    private void LevelCompleted()
    {
        Debug.Log("Level completed!");
    }
}
