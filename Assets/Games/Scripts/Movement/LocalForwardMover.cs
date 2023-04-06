using Games.Scripts.Utility.Data;
using UnityEngine;

namespace Games.Scripts.Movement
{
    public class LocalForwardMover : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private FloatData moveSpeed;

        private void Update() => targetTransform.position += targetTransform.forward * (moveSpeed.Value * Time.deltaTime);
    }
}