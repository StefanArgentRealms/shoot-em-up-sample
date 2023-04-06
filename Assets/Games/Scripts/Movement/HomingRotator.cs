using UnityEngine;

namespace Games.Scripts.Movement
{
    public class HomingRotator : MonoBehaviour
    {
        private const int MaxNumberOfTargetsToChooseFrom = 8;

        [SerializeField] private Transform homingTransform;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float homingRadius;
        [SerializeField] private LayerMask targetLayers;

        private readonly Collider[] potentialTargetColliders = new Collider[MaxNumberOfTargetsToChooseFrom];

        private void Update() => RotateTowardsClosestTarget();

        private void RotateTowardsClosestTarget()
        {
            var numberOfPotentialTargetsInRange = Physics.OverlapSphereNonAlloc(homingTransform.position, homingRadius, potentialTargetColliders, targetLayers);

            if (numberOfPotentialTargetsInRange == 0)
                return;

            var targetPosition = GetClosestTargetPosition(potentialTargetColliders, numberOfPotentialTargetsInRange);

            homingTransform.rotation = Quaternion.RotateTowards(
                homingTransform.rotation,
                Quaternion.LookRotation((targetPosition - homingTransform.position).normalized),
                rotationSpeed * Time.deltaTime);
        }

        private Vector3 GetClosestTargetPosition(Collider[] targets, int numberOfTargets)
        {
            var closestDistance = Mathf.Infinity;
            var closestTargetPosition = Vector3.zero;

            for (var i = 0; i < numberOfTargets; i++)
            {
                var targetPosition = targets[i].transform.position;
                var distanceToTarget = Vector3.Distance(homingTransform.position, targetPosition);

                if (distanceToTarget > closestDistance)
                    continue;

                closestDistance = distanceToTarget;
                closestTargetPosition = targetPosition;
            }

            return closestTargetPosition;
        }
    }
}