using Games.Scripts.Health;
using UnityEngine;

namespace Games.Scripts.Weapons
{
    public class PowerUpDropper : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private DeathController deathController;
        [SerializeField] private PowerUp powerUpPrefab;
        [SerializeField] [Range(0f, 1f)] private float dropChance = 0.5f;

        private void OnEnable() => deathController.OnDeath += CheckToDropPowerUp;

        private void OnDisable() => deathController.OnDeath -= CheckToDropPowerUp;

        private void CheckToDropPowerUp()
        {
            var rolledValue = Random.Range(0f, 1f);

            if (rolledValue > dropChance)
                return;

            Instantiate(powerUpPrefab, targetTransform.position, targetTransform.rotation);
        }
    }
}