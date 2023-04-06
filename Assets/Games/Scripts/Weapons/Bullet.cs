using Games.Scripts.Health.Data;
using Games.Scripts.Utility.Data;
using UnityEngine;

namespace Games.Scripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private FloatData damage;

        private bool hasDealtDamage;

        private void OnTriggerEnter(Collider other)
        {
            //Assumes that all valid targets has a rigidbody and that the HealthContainer is attached to the same GameObject as the rigidbody.

            //In certain cases the bullet can hit multiple colliders in a ship on the same frame.
            //This flag is used to make sure the bullet only deals damage once.
            //Other solutions would be to make sure that each ship only has one collider, or to make a custom collision system for bullets using raycasts.
            if (hasDealtDamage)
                return;

            if (other.attachedRigidbody == null)
                return;

            if (!other.attachedRigidbody.TryGetComponent<HealthContainer>(out var healthContainer))
                return;

            hasDealtDamage = true;

            healthContainer.Damage(damage.Value);
            Destroy(gameObject);
        }
    }
}