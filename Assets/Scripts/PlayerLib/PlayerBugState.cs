using UnityEngine;

namespace PlayerLib
{
    public class PlayerBugState : PlayerState
    {
        public override void PrimaryAction()
        {
            Debug.Log("Bug is absorbing energy");
        }
    }
}
