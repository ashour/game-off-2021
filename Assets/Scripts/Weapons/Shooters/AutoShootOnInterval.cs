using System.Collections;
using UnityEngine;
using Weapons.Cannons;

namespace Weapons.Shooters
{
    public class AutoShootOnInterval : MonoBehaviour
    {
        [SerializeField] private float _shotInterval = 3f;

        [SerializeField] private Cannon[] _cannons;

        private Coroutine _coroutine;

        private void OnDestroy()
        {
            if (_coroutine != null)
            {
                StopTimer();
            }
        }

        public void StartTimer(float warmUp = 0)
        {
            _coroutine = StartCoroutine(IntervalShoot(warmUp));
        }

        public void StopTimer()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator IntervalShoot(float warmUp)
        {
            if (warmUp > 0)
            {
                yield return new WaitForSeconds(warmUp);
            }

            while (true)
            {
                foreach (var cannon in _cannons)
                {
                    cannon.Fire();
                }

                yield return new WaitForSeconds(_shotInterval);
            }
        }
    }
}
