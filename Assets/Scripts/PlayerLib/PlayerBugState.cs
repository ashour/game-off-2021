using UnityEngine;

namespace PlayerLib
{
    public class PlayerBugState : PlayerState
    {
        public override void StartPrimaryAction()
        {
            Debug.Log("Bug is absorbing energy");
        }
    }
}
