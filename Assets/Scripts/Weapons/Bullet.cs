using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _body;

        private float _rotationSpeed;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rotationSpeed == 0) { return; }

            _body.rotation += _rotationSpeed * 100 * Time.fixedDeltaTime;
        }

        public void Fire(Vector2 velocity, float rotationSpeed = 0)
        {
            _body.AddForce(velocity, ForceMode2D.Impulse);
            _rotationSpeed = rotationSpeed;
        }
    }
}
