using UnityEngine;

namespace PlayerLib
{
    public class VState : PlayerState
    {
        [SerializeField] private Cannon _cannon;

        public override void PrimaryAction()
        {
            _cannon.Fire();
        }
    }
}
