using AI.Steps;
using UnityEngine;
using Weapons.Shooters;

namespace AI
{
    public class EnemySequence : MonoBehaviour
    {
        [SerializeField] private EnemySequenceStep[] _steps;

        private int _stepIndex = -1;

        private EnemySequenceStep Step =>
            _stepIndex > -1 && _stepIndex < _steps.Length ?
                _steps[_stepIndex] :
                null;

        public Rigidbody2DMover Mover { get; private set; }

        public AutoShootOnInterval IntervalShooter { get; private set; }

        private void Update()
        {
            if (Step)
            {
                Step.DoUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (Step)
            {
                Step.DoFixedUpdate();
            }
        }

        public void Init(
            AutoShootOnInterval intervalShooter,
            Rigidbody2DMover mover)
        {
            IntervalShooter = intervalShooter;
            Mover = mover;
            GoToNextStep();
        }

        public void SetShooter(AutoShootOnInterval intervalShooter) =>
            IntervalShooter = intervalShooter;

        public void SetMover(Rigidbody2DMover mover) => Mover = mover;

        public void OnStepComplete()
        {
            if (_stepIndex < _steps.Length)
            {
                GoToNextStep();
            }
        }

        private void GoToNextStep()
        {
            _stepIndex += 1;
            if (_stepIndex >= _steps.Length) { return; }
            Step.Enter(this);
        }
    }
}
