using Games.Scripts.Health.Data;
using Games.Scripts.Utility.Data;
using UnityEngine;

namespace Games.Scripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private FloatData damage;

        private void OnTriggerEnter(Collider other)
        {
            //Assumes that all valid targets has a rigidbody and that the HealthContainer is attached to the same GameObject as the rigidbody.

            if (other.attachedRigidbody == null)
                return;

            if (!other.attachedRigidbody.TryGetComponent<HealthContainer>(out var healthContainer))
                return;

            healthContainer.Damage(damage.Value);
            Destroy(gameObject);
        }
    }
}