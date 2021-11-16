using System;
using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class ShootOnInterval : MonoBehaviour
    {
        [SerializeField] private float _shotInterval = 3f;

        [SerializeField] private Cannon _cannon;

        private Coroutine _coroutine;

        private void OnDestroy()
        {
            if (_coroutine != null)
            {
                StopTimer();
            }
        }

        public void StartTimer()
        {
            _coroutine = StartCoroutine(IntervalShoot());
        }

        public void StopTimer()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator IntervalShoot()
        {
            while (true)
            {
                _cannon.Fire();

                yield return new WaitForSeconds(_shotInterval);
            }
        }
    }
}