using Games.Scripts.Weapons.Data;
using UnityEngine;

namespace Games.Scripts.Weapons
{
    public class PowerUp : MonoBehaviour
    {
        private const int LevelsToAddWhenCollected = 1;

        private bool hasAppliedPowerUp;

        private void OnTriggerEnter(Collider other)
        {
            if (hasAppliedPowerUp)
                return;

            if (other.attachedRigidbody == null)
                return;

            if (!other.attachedRigidbody.TryGetComponent<PowerLevelContainer>(out var powerLevelContainer))
                return;

            hasAppliedPowerUp = true;

            powerLevelContainer.AddToPowerLevel(LevelsToAddWhenCollected);
            Destroy(gameObject);
        }
    }
}