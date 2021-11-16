using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionNotifier : MonoBehaviour
{
    public Action<GameObject> OnTriggered;
    public Action<GameObject> OnCollided;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggered?.Invoke(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollided?.Invoke(other.gameObject);
    }
}
