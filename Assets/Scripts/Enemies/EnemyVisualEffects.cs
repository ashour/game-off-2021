using UnityEngine;

namespace Enemies
{
    public class EnemyVisualEffects : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private GameObject _hitEffect;

        private void OnEnable()
        {
            Enemy.OnEnemyDied += OnEnemyDied;
        }

        private void OnDestroy()
        {
            Enemy.OnEnemyDied -= OnEnemyDied;
        }

        private void OnEnemyDied(Enemy enemy, int _)
        {
            if (_enemy != enemy) { return; }

            Instantiate(_hitEffect, transform.position, Quaternion.identity);
        }
    }
}
