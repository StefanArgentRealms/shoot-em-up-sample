using Games.Scripts.Health.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Games.Scripts.Health.UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private Text healthText;
        [SerializeField] private HealthContainer playerHealthContainer;

        private void OnEnable() => playerHealthContainer.OnHealthChanged += UpdateHealthText;

        private void OnDisable() => playerHealthContainer.OnHealthChanged -= UpdateHealthText;

        private void UpdateHealthText(float health) => healthText.text = $"Health: {Mathf.CeilToInt(health)}";
    }
}