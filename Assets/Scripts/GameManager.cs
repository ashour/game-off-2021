using Scrolling;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScrollingBackground _background;

    private void Awake() => _background.Scroll(true);
}
