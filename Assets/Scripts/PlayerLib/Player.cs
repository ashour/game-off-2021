using System;
using DG.Tweening;
using Health;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerLib
{
    [RequireComponent(
        typeof(Rigidbody2DMover),
        typeof(HasHealth))]
    public class Player : MonoBehaviour
    {
        public static Action<PlayerState, PlayerState> OnWillSwitchState;
        public static Action<PlayerState> OnStateSwitched;

        [SerializeField] private PlayerState _currentState;
        public PlayerState CurrentState => _currentState;

        [SerializeField] private float _transitionDuration = 0.2f;

        private Vector2 _movement;
        private bool _isTransitioning;

        private Rigidbody2DMover _mover;
        private HasHealth _hasHealth;

        private void Awake()
        {
            _mover = GetComponent<Rigidbody2DMover>();
            _hasHealth = GetComponent<HasHealth>();
        }

        private void OnEnable()
        {
            _hasHealth.OnDied += Die;
        }

        private void OnDisable()
        {
            _hasHealth.OnDied -= Die;
        }

        private void Update()
        {
            if (_isTransitioning) { return; }

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
                _currentState.StartPrimaryAction();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                _currentState.EndPrimaryAction();
            }
        }

        private void FixedUpdate()
        {
            _mover.Move(_movement, _currentState.MovementSpeed);
        }

        private void NextState(PlayerState nextState)
        {
            _isTransitioning = true;

            OnWillSwitchState?.Invoke(_currentState, nextState);

            _currentState.transform
                .DOScale(0, _transitionDuration / 2)
                .OnComplete(() =>
            {
                _currentState.gameObject.SetActive(false);
                _currentState.transform.localScale = Vector3.one;

                nextState.transform.localScale = Vector3.zero;
                nextState.gameObject.SetActive(true);

                nextState.transform
                    .DOScale(1, _transitionDuration / 2)
                    .OnComplete(() =>
                {
                    _currentState = nextState;
                    _isTransitioning = false;
                    OnStateSwitched?.Invoke(_currentState);
                });
            });
        }

        private void Die()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
