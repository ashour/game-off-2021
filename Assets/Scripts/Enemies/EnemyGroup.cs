using AI;
using UnityEngine;

namespace Enemies
{
    //TODO make single enemy not group
    public class EnemyGroup : MonoBehaviour
    {
        private Enemy[] _enemies;

        private void Awake()
        {
            _enemies = GetComponentsInChildren<Enemy>();
        }

        public void Init(EnemySequence sequence)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Init(sequence);
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
