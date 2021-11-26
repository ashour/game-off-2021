using UnityEngine;
using Weapons.Shooters;

namespace AI.Steps
{
    public abstract class EnemySequenceStep : MonoBehaviour
    {
        [SerializeField] private bool _startShootingOnEnter;

        protected EnemySequence Sequence { get; private set; }

        protected AutoShootOnInterval IntervalShooter =>
            Sequence.IntervalShooter;

        protected Rigidbody2DMover Mover => Sequence.Mover;

        public void Enter(EnemySequence sequence)
        {
            Sequence = sequence;

            if (IntervalShooter && _startShootingOnEnter)
            {
                IntervalShooter.StartTimer();
            }

            DoEnter();
        }


        public virtual void DoEnter() {}

        public virtual void DoUpdate() {}

        public virtual void DoFixedUpdate() {}

        protected void OnStepComplete() => Sequence.OnStepComplete();
    }
}
