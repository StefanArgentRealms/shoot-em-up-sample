using UnityEngine;

namespace Games.Scripts.Movement.Data
{
    [CreateAssetMenu(menuName = "Shoot Em Up/Data/Movement Curve Set", fileName = "MovementCurveSet", order = 0)]
    public class MovementCurveSet : ScriptableObject
    {
        [SerializeField] private AnimationCurve horizontalMovementCurve = AnimationCurve.Linear(0, 1, 1, 1);
        [SerializeField] private AnimationCurve verticalMovementCurve = AnimationCurve.Linear(0, 0, 1, 0);
        [SerializeField] private float movementDuration = 10f;

        public float MovementDuration => movementDuration;

        public Vector3 EvaluateAtProgress(float progress) => new(0, verticalMovementCurve.Evaluate(progress), horizontalMovementCurve.Evaluate(progress));
    }
}