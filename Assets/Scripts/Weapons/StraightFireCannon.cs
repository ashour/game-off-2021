using UnityEngine;

namespace Weapons
{
    public class StraightFireCannon : Cannon
    {
        [SerializeField] private Vector2 _fireVelocity;

        public override void Fire()
        {
            var bullet =
                Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            bullet.Fire(_fireVelocity);
        }
    }
}
