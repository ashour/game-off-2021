using UnityEngine;

namespace Player
{
    public class VState : PlayerState
    {
        public override void PrimaryAction()
        {
            Debug.Log("V is shooting");
        }
    }
}
