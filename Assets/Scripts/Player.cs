using System;
using UnityEngine;

[RequireComponent(typeof(RigidBody2dMover))]
public class Player : MonoBehaviour
{
    public static Action<PlayerState> OnStateSwitched;

    [SerializeField] private PlayerState _currentState;

    private Vector2 _movement;
    private RigidBody2dMover _mover;

    private void Awake()
    {
        _mover = GetComponent<RigidBody2dMover>();
    }

    private void Update()
    {
        _movement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift) ||
            Input.GetKeyDown(KeyCode.RightShift))
        {
            NextState(_currentState.NextState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentState.PrimaryAction();
        }
    }

    private void FixedUpdate()
    {
        _mover.Move(_movement, _currentState.MovementSpeed);
    }

    private void NextState(PlayerState nextState)
    {
        _currentState.gameObject.SetActive(false);
        _currentState = nextState;
        _currentState.gameObject.SetActive(true);
        OnStateSwitched?.Invoke(_currentState);
    }
}
