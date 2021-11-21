using UnityEngine;
using Weapons;
using Weapons.Shooters;

namespace PlayerLib
{
    public class PlayerVState : PlayerState
    {
        [SerializeField] private ShootWithCooldown _shooter;

        public override void StartPrimaryAction()
        {
            _shooter.StartFire();
        }

        public override void EndPrimaryAction()
        {
            _shooter.EndFire();
        }
    }
}
