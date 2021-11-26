using UnityEngine;

namespace AI.Steps
{
    public class WaypointMover : EnemySequenceStep
    {
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private float _moveSpeed;

        private int _waypointIndex = 0;

        public override void DoEnter()
        {
            Debug.Log($"{nameof(WaypointMover)}.{nameof(Enter)}()");
        }

        public override void DoFixedUpdate()
        {
            if (!Mover) { return; }

            var currentWaypoint = _waypoints[_waypointIndex];

            //TODO add pause at waypoint
            if (Mover.HasReached(currentWaypoint.position))
            {
                _waypointIndex += 1;

                if (_waypointIndex >= _waypoints.Length)
                {
                    OnStepComplete();
                }

                return;
            }

            Mover.MoveTowards(currentWaypoint.position, _moveSpeed);
        }
    }
}
