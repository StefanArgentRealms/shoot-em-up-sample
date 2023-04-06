using System;
using UnityEngine;

namespace Games.Scripts.Weapons.Data
{
    public class PowerLevelContainer : MonoBehaviour
    {
        [SerializeField] [Range(1, 3)] private int powerLevel = 1;
        [SerializeField] private int maxPowerLevel = 3;

        public Action<int> OnPowerLevelChanged = default;

        public int PowerLevel => powerLevel;

        public void AddToPowerLevel(int levelsToAdd)
        {
            powerLevel = Mathf.Clamp(powerLevel + levelsToAdd, 0, maxPowerLevel);
            OnPowerLevelChanged?.Invoke(powerLevel);
        }
    }
}