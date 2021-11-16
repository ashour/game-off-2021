using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerNotifier : MonoBehaviour
{
    public Action<GameObject> OnTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggered?.Invoke(other.gameObject);
    }
}
