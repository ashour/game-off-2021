using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class ShootWithCooldown : MonoBehaviour
    {
        [SerializeField] private Cannon[] _cannons;
        [SerializeField] private float _coolDown = 0.2f;

        private bool _isFiring;
        private float _timer;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitUntil(() => _isFiring);

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

        public void StartFire()
        {
            _isFiring = true;
            _timer = 0;
        }

        public void EndFire()
        {
            _isFiring = false;
        }
    }
}
