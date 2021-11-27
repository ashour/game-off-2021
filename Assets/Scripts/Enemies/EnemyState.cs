using AI;
using UnityEngine;
using UnityEngine.Events;
using Weapons.Shooters;

namespace Enemies
{
    public class EnemyState : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        public GameObject Root => _root;

        [SerializeField] private AutoShootOnInterval _intervalShooter;
        public AutoShootOnInterval IntervalShooter => _intervalShooter;

        [SerializeField] private Rigidbody2DMover _mover;
        public Rigidbody2DMover Mover => _mover;


        [Header("Instancing")]
        [SerializeField] private UnityEvent _onInstanced;
        [Tooltip("Called once per enemy lifecycle, after instancing")]
        [SerializeField] private UnityEvent _onFirstEnter;

        [Header("Player")]
        [SerializeField] private UnityEvent _onPlayerWillBecomeV;
        [SerializeField] private UnityEvent _onPlayerWillBecomeBug;

        [Header("State mainstays")]
        [Tooltip("Every time state is entered")]
        [SerializeField] private UnityEvent _onEnter;
        [Tooltip("Every time state is exited")]
        [SerializeField] private UnityEvent _onExit;

        public void Init()
        {
            _onInstanced?.Invoke();
        }

        public void FirstEnter() => _onFirstEnter?.Invoke();

        public void EnterState() => _onEnter?.Invoke();

        public void ExitState() => _onExit?.Invoke();

        public void PlayerWillBecomeV() => _onPlayerWillBecomeV?.Invoke();

        public void PlayerWillBecomeBug() => _onPlayerWillBecomeBug?.Invoke();
    }
}
