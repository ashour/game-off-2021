using UnityEngine;

namespace Health
{
    [RequireComponent(typeof(HasHealth))]
    public class DamageReceiver : MonoBehaviour
    {
        private HasHealth _hasHealth;

        private CollisionNotifier[] _triggerNotifiers;

        private void Awake()
        {
            _hasHealth = GetComponent<HasHealth>();
        }

        private void OnEnable()
        {
            _triggerNotifiers = GetComponentsInChildren<CollisionNotifier>();

            foreach (var notifier in _triggerNotifiers)
            {
                notifier.OnTriggered += TakeDamageFrom;
            }
        }

        private void OnDisable()
        {
            foreach (var notifier in _triggerNotifiers)
            {
                notifier.OnTriggered -= TakeDamageFrom;
            }
        }

        private void TakeDamageFrom(GameObject obj)
        {
            var damageDealer = obj.GetComponent<DamageDealer>();

            if (damageDealer is not null)
            {
                _hasHealth.TakeDamage(damageDealer.Damage);
                Destroy(obj);
            }
        }
    }
}
