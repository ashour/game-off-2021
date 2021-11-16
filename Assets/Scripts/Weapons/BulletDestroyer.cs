using UnityEngine;

namespace Weapons
{
    public class BulletDestroyer : MonoBehaviour
    {
        [SerializeField] private CollisionNotifier _collisionNotifier;

        private void OnEnable()
        {
            _collisionNotifier.OnTriggered += DestroyBullet;
        }

        private void OnDisable()
        {
            _collisionNotifier.OnTriggered -= DestroyBullet;
        }

        private static void DestroyBullet(GameObject bullet)
        {
            Destroy(bullet);
        }
    }
}
