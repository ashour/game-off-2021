using System;
using UnityEngine;

namespace Health
{
    public class HasHealth : MonoBehaviour
    {
        public Action<float> OnHealthChanged;
        public Action OnDied;

        [SerializeField] private float _maxHealth = 1;
        [SerializeField] private float _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float amount)
        {
            if (_currentHealth == 0) {return;}

            _currentHealth =
                Mathf.Clamp(_currentHealth - amount, 0, _maxHealth);

            OnHealthChanged?.Invoke(_currentHealth);

            if (_currentHealth == 0)
            {
                OnDied?.Invoke();
            }
        }
    }
}
