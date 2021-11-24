using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rigidbody2DMover : MonoBehaviour
{
    private Rigidbody2D _body;

    [Tooltip("Whether to add to the configured base movement speed to the body")]
    [SerializeField] private bool _usesBaseScrollSpeed;
    [SerializeField] private GameConfig _config;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction, float speed)
    {
        var baseMovement = _usesBaseScrollSpeed
            ? new Vector2(0, _config.AutoScrollSpeed * Time.fixedDeltaTime)
            : Vector2.zero;

        var addedMovement = direction * (speed * Time.fixedDeltaTime);

        _body.MovePosition(_body.position + baseMovement + addedMovement);
    }
}
