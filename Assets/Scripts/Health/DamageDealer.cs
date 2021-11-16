using UnityEngine;

namespace Health
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private float _damage;
        public float Damage => _damage;

        [SerializeField] private bool _destroyOnDamage;
        public bool DestroyOnDealDamage => _destroyOnDamage;
    }
}
