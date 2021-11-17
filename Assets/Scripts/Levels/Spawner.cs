using DG.Tweening;
using Enemies;
using UnityEngine;

namespace Levels
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _moveToDestinationDuration = 2;

        public void Spawn(EnemySpawn[] spawns)
        {
            foreach (var spawn in spawns)
            {
                var group = Instantiate(spawn.GroupPrefab);
                group.gameObject.SetActive(false);
                group.transform.position = spawn.SpawnPoint.position;

                DOTween.Sequence()
                    .AppendCallback(() => group.gameObject.SetActive(true))
                    .Append(group.transform.DOMove(
                        spawn.DestinationPoint.position, _moveToDestinationDuration))
                    .AppendCallback(() => group.Init());
            }
        }
    }
}
