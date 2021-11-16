using UnityEngine;
using Weapons;

namespace PlayerLib
{
    public class PlayerVState : PlayerState
    {
        [SerializeField] private Cannon _cannon;

        public override void PrimaryAction()
        {
            _cannon.Fire();
        }
    }
}
