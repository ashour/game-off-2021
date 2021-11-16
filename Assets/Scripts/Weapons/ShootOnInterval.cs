using System.Collections;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Cannon))]
    public class ShootOnInterval : MonoBehaviour
    {
        [SerializeField] private float _shotInterval = 3f;

        private Cannon _cannon;

        private Coroutine _coroutine;

        private void Awake()
        {
            _cannon = GetComponent<Cannon>();
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
