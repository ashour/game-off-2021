using UnityEngine;

[CreateAssetMenu(menuName = "Game Config", order = 0)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private float _autoScrollSpeed;
    public float AutoScrollSpeed => _autoScrollSpeed;
}
