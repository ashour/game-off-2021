using AI;
using AI.Steps;
using Enemies;
using UnityEngine;

namespace Spawning
{
    public class Spawner : MonoBehaviour
    {
        public static void Spawn(EnemySpawn spawn, EnemySequence sequence)
        {
            InitGroupAt(
                spawn.GroupPrefab, spawn.SpawnPoint.position, sequence);
        }

        private static void InitGroupAt(
            EnemyGroup prefab, Vector2 position, EnemySequence sequence)
        {
            var group = Instantiate(prefab);
            group.Init(sequence);
            group.gameObject.SetActive(false);
            group.transform.position = position;
            group.gameObject.SetActive(true);
            group.FirstEnter();
        }
    }
}
