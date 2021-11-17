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

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.J))
    //     {
    //         _background.Scroll(true);
    //
    //         var group = Instantiate(_enemySpawn.GroupPrefab);
    //         group.gameObject.SetActive(false);
    //         group.transform.position = _enemySpawn.SpawnPoint.position;
    //
    //         DOTween.Sequence()
    //             .AppendInterval(3)
    //             .AppendCallback(() => group.gameObject.SetActive(true))
    //             .Append(group.transform.DOMove(
    //                 _enemySpawn.DestinationPoint.position, 2))
    //             .AppendCallback(() => group.Init());
    //     }
    // }
}
