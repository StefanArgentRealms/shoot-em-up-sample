using System;
using Games.Scripts.Utility.Data;
using UnityEngine;

namespace Games.Scripts.Health.Data
{
    public class HealthContainer : MonoBehaviour
    {
        [SerializeField] private FloatData startHealth;

        private float currentHealth;

        public Action<float> OnDamageTaken = default;

        private void Start() => currentHealth = startHealth.Value;

        public void Damage(float damage)
        {
            currentHealth -= damage;
            OnDamageTaken?.Invoke(currentHealth);
        }
    }
}