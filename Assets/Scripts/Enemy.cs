using Health;
using UnityEngine;

[RequireComponent(typeof(HasHealth))]
public class Enemy : MonoBehaviour
{
    private HasHealth _hasHealth;

    private void Awake()
    {
        _hasHealth = GetComponent<HasHealth>();
    }

    private void OnEnable()
    {
        _hasHealth.OnDied += Die;
    }

    private void OnDisable()
    {
        _hasHealth.OnDied -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
