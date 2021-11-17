using System;
using Enemies;

// ReSharper disable InconsistentNaming

namespace Levels
{
    [Serializable]
    public class Section
    {
        public float WarmUpDuration;
        public EnemySpawn[] Spawns;
    }
}
