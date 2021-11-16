using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        Player.OnStateSwitched += TestEvent;
    }

    private void OnDisable()
    {
        Player.OnStateSwitched -= TestEvent;
    }

    private void TestEvent(PlayerState state)
    {
        Debug.Log($"Player switched to {state}");
    }
}
