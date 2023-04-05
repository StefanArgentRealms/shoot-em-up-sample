using UnityEngine;

namespace Games.Scripts.Movement
{
    public class PositionLimiter : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector2 xPositionRange;
        [SerializeField] private Vector2 yPositionRange;

        private void LateUpdate() => LimitPosition();

        private void LimitPosition()
        {
            var position = targetTransform.position;

            position.x = Mathf.Clamp(position.x, xPositionRange.x, xPositionRange.y);
            position.y = Mathf.Clamp(position.y, yPositionRange.x, yPositionRange.y);

            targetTransform.position = position;
        }
    }
}