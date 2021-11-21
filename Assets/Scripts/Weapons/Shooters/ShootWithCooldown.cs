using System.Collections;
using UnityEngine;
using Weapons.Cannons;

namespace Weapons.Shooters
{
    public class ShootWithCooldown : MonoBehaviour
    {
        [SerializeField] private Cannon[] _cannons;
        [SerializeField] private float _coolDown = 0.2f;

        private float _timer;
        private Coroutine _coroutine;

        public void StartFire()
        {
            _timer = 0;
            _coroutine = StartCoroutine(ShootOnCooldown());
        }

        public void EndFire()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator ShootOnCooldown()
        {
            while (true)
            {
                if (_timer > 0)
                {
                    yield return new WaitForSeconds(_timer);
                }

                foreach (var cannon in _cannons)
                {
                    cannon.Fire();
                }

                _timer = _coolDown;
            }
        }
    }
}
