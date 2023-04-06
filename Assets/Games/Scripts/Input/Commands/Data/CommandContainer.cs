using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("ShootEmUp.Input.Player")]
[assembly: InternalsVisibleTo("ShootEmUp.Input.AI")]
namespace Games.Scripts.Input.Commands.Data
{
    public class CommandContainer : MonoBehaviour
    {
        public Vector3 Move { get; internal set; }
        public bool Shoot { get; internal set; }
    }
}
