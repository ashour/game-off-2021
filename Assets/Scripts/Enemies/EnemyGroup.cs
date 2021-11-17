using UnityEngine;

namespace Enemies
{
    public class EnemyGroup : MonoBehaviour
    {
        private Enemy[] _enemies;

        private void Awake()
        {
            _enemies = GetComponentsInChildren<Enemy>();
        }

        public void Init()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Init();
            }
        }

        public void FirstEnter()
        {
            foreach (var enemy in _enemies)
            {
                enemy.FirstEnter();
            }
        }
    }
}
