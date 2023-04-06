using Games.Scripts.Input.Commands.Data;
using Games.Scripts.Utility.Data;
using UnityEngine;

namespace Games.Scripts.Movement
{
    public class DefaultMovementController : MonoBehaviour
    {
        [SerializeField] private CommandContainer commandContainer;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private FloatData moveSpeed;

        private void Update() => ApplyMovement(Time.deltaTime);

        private void ApplyMovement(float deltaTime) => targetTransform.position += commandContainer.Move * (deltaTime * moveSpeed.Value);
    }
}