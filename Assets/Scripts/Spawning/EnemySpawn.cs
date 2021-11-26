using System;
using Enemies;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Spawning
{
    [Serializable]
    public class EnemySpawn
    {
        public EnemyGroup GroupPrefab;
        public Transform SpawnPoint;
    }
}
