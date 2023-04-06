using System;
using Games.Scripts.Health.Data;
using UnityEngine;

namespace Games.Scripts.Health
{
    public class DeathController : MonoBehaviour
    {
        [SerializeField] private HealthContainer healthContainer;
        [SerializeField] private GameObject objectToDestroyOnDeath;

        public Action OnDeath = default;

        private void OnEnable() => healthContainer.OnHealthChanged += CheckHealth;

        private void OnDisable() => healthContainer.OnHealthChanged -= CheckHealth;

        private void CheckHealth(float health)
        {
            if (health > 0)
                return;

            OnDeath?.Invoke();
            Destroy(objectToDestroyOnDeath);
        }
    }
}