using PlayerLib;
using UnityEngine;

public class PlayerStateSwitchResponder : MonoBehaviour
{
    [SerializeField] private GameObject _enabledInVState;
    [SerializeField] private GameObject _enabledInBugState;

    private void OnEnable()
    {
        UpdateForPlayerState(FindObjectOfType<Player>().CurrentState);

        Player.OnStateSwitched += UpdateForPlayerState;
    }

    private void OnDisable()
    {
        Player.OnStateSwitched -= UpdateForPlayerState;
    }

    private void UpdateForPlayerState(PlayerState newState)
    {
        switch (newState)
        {
            case PlayerVState:
                _enabledInBugState.SetActive(false);
                _enabledInVState.SetActive(true);
                break;

            case PlayerBugState:
                _enabledInVState.SetActive(false);
                _enabledInBugState.SetActive(true);
                break;
        }
    }
}
