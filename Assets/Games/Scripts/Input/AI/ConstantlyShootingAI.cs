using Games.Scripts.Input.Commands.Data;
using UnityEngine;

namespace Games.Scripts.Input.AI
{
    public class ConstantlyShootingAI : MonoBehaviour
    {
        [SerializeField] private CommandContainer commandContainer;

        private void OnEnable() => commandContainer.Shoot = true;
    }
}