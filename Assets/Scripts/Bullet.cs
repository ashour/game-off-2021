using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 velocity)
    {
        _body.AddForce(velocity, ForceMode2D.Impulse);
    }
}
