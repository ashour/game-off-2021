using UnityEngine;

namespace PlayerLib
{
    public class BugState : PlayerState
    {
        public override void PrimaryAction()
        {
            Debug.Log("Bug is absorbing energy");
        }
    }
}
