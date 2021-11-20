using System;
using Health;
using PlayerLib;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(HasHealth))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyState _currentState;

        public static Action<Enemy> OnEnemyDied;

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

        public void GoTo(EnemyState nextState)
        {
            _currentState.ExitState();
            _currentState.Root.SetActive(false);

            _currentState = nextState;

            _currentState.Root.SetActive(true);
            _currentState.EnterState();
        }

        private void OnPlayerWillSwitchState(
            PlayerState currentPlayerState,
            PlayerState nextPlayerState)
        {
            switch (nextPlayerState)
            {
                case PlayerBugState:
                    _currentState.PlayerWillBecomeBug();
                    break;
                case PlayerVState:
                    _currentState.PlayerWillBecomeV();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(nextPlayerState));
            }
        }

        private void Die()
        {
            OnEnemyDied?.Invoke(this);
            
            Destroy(gameObject);
        }

        public void Init() => _currentState.Init();

        public void FirstEnter() => _currentState.FirstEnter();
    }
}
