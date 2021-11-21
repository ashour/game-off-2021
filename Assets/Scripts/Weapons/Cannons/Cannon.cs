using UnityEngine;

namespace Weapons.Cannons
{
    public abstract class Cannon : MonoBehaviour
    {
        [SerializeField] protected Bullet _bulletPrefab;

        public abstract void Fire();
    }
}
