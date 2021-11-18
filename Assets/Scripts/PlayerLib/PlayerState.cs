using UnityEngine;

namespace PlayerLib
{
    public abstract class PlayerState : MonoBehaviour
    {
        [SerializeField] private PlayerState _nextState;
        public PlayerState NextState => _nextState;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        public virtual void StartPrimaryAction() {}

        public virtual void EndPrimaryAction() { }
    }
}
