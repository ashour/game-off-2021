using System;
using Health;
using PlayerLib;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(HasHealth))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyState _vState;
        [SerializeField] private EnemyState _bugState;
        [SerializeField] private EnemyState _currentState;

        private HasHealth _hasHealth;

        private void Awake()
        {
            _hasHealth = GetComponent<HasHealth>();
        }

        private void OnEnable()
        {
            Player.OnWillSwitchState += OnPlayerWillSwitchState;

            _hasHealth.OnDied += Die;
        }

        private void OnDisable()
        {
            Player.OnWillSwitchState -= OnPlayerWillSwitchState;

            _hasHealth.OnDied -= Die;
        }

        private void OnPlayerWillSwitchState(
            PlayerState currentPlayerState,
            PlayerState nextPlayerState)
        {
            _currentState.ExitState();
            _currentState.gameObject.SetActive(false);

            _currentState = nextPlayerState switch
            {
                PlayerVState => _vState,
                PlayerBugState => _bugState,
                _ => throw new ArgumentException(
                    $"Unrecognized player state {nextPlayerState}")
            };

            _currentState.gameObject.SetActive(true);
            _currentState.EnterState();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void Init() => _currentState.Init();
    }
}
