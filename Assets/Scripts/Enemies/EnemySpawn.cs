using System;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace Enemies
{
    [Serializable]
    public class EnemySpawn
    {
        public EnemyGroup GroupPrefab;
        public Transform SpawnPoint;
        public Transform DestinationPoint;
    }
}
