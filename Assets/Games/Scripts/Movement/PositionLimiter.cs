using UnityEngine;

namespace Games.Scripts.Movement
{
    public class PositionLimiter : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector2 yPositionRange;
        [SerializeField] private Vector2 zPositionRange;

        private void LateUpdate() => LimitPosition();

        private void LimitPosition()
        {
            var position = targetTransform.position;

            position.y = Mathf.Clamp(position.y, yPositionRange.x, yPositionRange.y);
            position.z = Mathf.Clamp(position.z, zPositionRange.x, zPositionRange.y);

            targetTransform.position = position;
        }
    }
}