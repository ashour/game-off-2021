using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class EnemyState : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onEnter;
        [SerializeField] private UnityEvent _onExit;

        public void EnterState() => _onEnter?.Invoke();

        public void ExitState() => _onExit?.Invoke();
    }
}
