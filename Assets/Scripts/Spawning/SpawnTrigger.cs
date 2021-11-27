using AI;
using UnityEngine;

namespace Spawning
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemySpawn _spawn;
        [SerializeField] private EnemySequence _sequence;

        private void Awake()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Spawner.Spawn(_spawn, _sequence);
        }
    }
}
