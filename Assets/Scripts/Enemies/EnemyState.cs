using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class EnemyState : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        public GameObject Root => _root;

        [Header("Events")]
        [SerializeField] private UnityEvent _onInstanced;
        [SerializeField] private UnityEvent _onFirstEnter;
        [SerializeField] private UnityEvent _onPlayerWillBecomeV;
        [SerializeField] private UnityEvent _onPlayerWillBecomeBug;

        [Header("State Enter & Exit")]
        [SerializeField] private UnityEvent _onEnter;
        [SerializeField] private UnityEvent _onExit;

        public void Init() => _onInstanced?.Invoke();

        public void FirstEnter() => _onFirstEnter?.Invoke();

        public void EnterState() => _onEnter?.Invoke();

        public void ExitState() => _onExit?.Invoke();

        public void PlayerWillBecomeV() => _onPlayerWillBecomeV?.Invoke();

        public void PlayerWillBecomeBug() => _onPlayerWillBecomeBug?.Invoke();
    }
}
