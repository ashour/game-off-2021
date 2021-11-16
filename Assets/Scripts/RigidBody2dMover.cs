using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidBody2dMover : MonoBehaviour
{
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction, float speed)
    {
        _body.MovePosition(
            (Vector2)transform.position +
            direction * (speed * Time.fixedDeltaTime));
    }
}
