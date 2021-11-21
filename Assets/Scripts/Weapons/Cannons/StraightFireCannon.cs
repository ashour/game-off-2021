using UnityEngine;

namespace Weapons.Cannons
{
    public class StraightFireCannon : Cannon
    {
        [SerializeField] private Vector2 _fireVelocity;

        public override void Fire() => MakeBullet().Fire(_fireVelocity);
    }
}
