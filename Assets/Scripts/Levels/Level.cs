using System;
using System.Collections;
using Enemies;
using UnityEngine;

namespace Levels
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _sectionIndex = -1;
        [SerializeField] private Section[] _sections;
        [SerializeField] private Spawner _spawner;

        public static Action OnLevelSectionsCompleted;

        private void Awake() => StartCoroutine(NextSection());

        private void OnEnable()
        {
            Enemy.OnEnemyDied += NextSectionIfCurrentSectionCompleted;
        }

        private void OnDisable()
        {
            Enemy.OnEnemyDied -= NextSectionIfCurrentSectionCompleted;
        }

        private IEnumerator NextSection()
        {
            _sectionIndex += 1;

            if (_sectionIndex == _sections.Length)
            {
                OnLevelSectionsCompleted?.Invoke();
                yield break;
            }

            var currentSection = _sections[_sectionIndex];

            if (currentSection.WarmUpDuration > 0)
            {
                yield return new WaitForSeconds(currentSection.WarmUpDuration);
            }

            _spawner.Spawn(currentSection.Spawns);
        }

        private void NextSectionIfCurrentSectionCompleted(
            Enemy _, int enemyCount)
        {
            if (enemyCount == 0)
            {
                StartCoroutine(NextSection());
            }
        }
    }
}
