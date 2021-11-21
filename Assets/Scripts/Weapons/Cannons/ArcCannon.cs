using UnityEngine;

namespace Weapons.Cannons
{
    public class ArcCannon : Cannon
    {
        private const float TwoPI = Mathf.PI * 2;

        [Header("Bullets")]
        [SerializeField] private int _bulletCount = 1;
        [SerializeField] private float _fireForce = 1;
        [SerializeField] private float _bulletRotationSpeed;

        [Header("Offsets")]
        [SerializeField] private bool _useAsGap;

        [Tooltip("Angle, in degrees, to start bullet spread.")]
        [SerializeField] private float _startAngle = 0;

        [Tooltip("Angle, in degrees, to end bullet spread.")]
        [SerializeField] private float _endingAngle = 360;

        private void OnValidate()
        {
            if (_bulletCount <= 0)
            {
                _bulletCount = 1;
            }

            if (_startAngle < 0)
            {
                _startAngle = 0;
            }

            if (_endingAngle < 0)
            {
                _endingAngle = 0;
            }
        }

        public override void Fire()
        {
            var startingAngleInRad = _useAsGap ?
                0 :
                _startAngle * Mathf.Deg2Rad;

            var endingAngleInRad = _useAsGap ?
                TwoPI :
                _endingAngle * Mathf.Deg2Rad;

            var distanceBetweenBullets =
                (endingAngleInRad - startingAngleInRad) / _bulletCount;

            float gapStartingAngle = 0;
            float gapEndingAngle = 0;

            if (_useAsGap)
            {
                gapStartingAngle = _startAngle * Mathf.Deg2Rad;
                gapEndingAngle = _endingAngle * Mathf.Deg2Rad;
            }

            for (var theta = startingAngleInRad;
                theta <= endingAngleInRad;
                theta += distanceBetweenBullets)
            {
                if (!_useAsGap || (theta < gapStartingAngle || theta > gapEndingAngle))
                {
                    var velocity =
                        new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) *
                        _fireForce;

                    MakeBullet().Fire(velocity, _bulletRotationSpeed);
                }
            }
        }
    }
}
