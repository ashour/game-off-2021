using UnityEngine;

namespace Weapons
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private Vector2 _fireVelocity;

        public void Fire()
        {
            var bullet =
                Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            bullet.Fire(_fireVelocity);
        }
    }
}
