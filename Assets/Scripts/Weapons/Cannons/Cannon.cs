using UnityEngine;

namespace Weapons.Cannons
{
    public abstract class Cannon : MonoBehaviour
    {
        [SerializeField] protected Bullet _bulletPrefab;

        public abstract void Fire();

        protected Bullet MakeBullet()
        {
            return Instantiate(
                _bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
