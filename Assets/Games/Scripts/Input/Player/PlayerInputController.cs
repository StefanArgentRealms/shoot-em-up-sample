using Games.Scripts.Input.Commands.Data;
using UnityEngine;

namespace Games.Scripts.Input.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private CommandContainer commandContainer;

        private void Update() => ProcessInputs();

        private void ProcessInputs()
        {
            ProcessMoveInput();
            commandContainer.Shoot = UnityEngine.Input.GetButton("Fire1");
        }

        private void ProcessMoveInput()
        {
            //In a bigger project I would use Unity's new Input System instead of the legacy one.
            var move = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"), 0);

            var moveMagnitude = move.magnitude;

            if (moveMagnitude > 0)
                move = moveMagnitude * move.normalized;

            commandContainer.Move = move;
        }
    }
}