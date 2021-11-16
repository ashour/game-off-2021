using UnityEngine;

namespace PlayerLib
{
    public class VState : PlayerState
    {
        public override void PrimaryAction()
        {
            Debug.Log("V is shooting");
        }
    }
}
