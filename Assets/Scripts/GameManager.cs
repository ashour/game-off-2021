using Levels;
using Scrolling;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
