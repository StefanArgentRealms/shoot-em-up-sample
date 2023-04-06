using Games.Scripts.Weapons.Data;
using UnityEngine;

namespace Games.Scripts.Weapons
{
    public class WeaponsPowerController : MonoBehaviour
    {
        [SerializeField] private PowerLevelContainer powerLevelContainer;
        [SerializeField] private GameObject[] weaponLevelParents;

        private void OnEnable()
        {
            CheckPowerLevel(powerLevelContainer.PowerLevel);
            powerLevelContainer.OnPowerLevelChanged += CheckPowerLevel;
        }

        private void OnDisable() => powerLevelContainer.OnPowerLevelChanged -= CheckPowerLevel;

        private void CheckPowerLevel(int powerLevel)
        {
            //Assumes that power level is kept within expected ranges (currently 1-3).
            for (var i = 0; i < powerLevel; i++)
            {
                if (i == powerLevel - 1)
                {
                    weaponLevelParents[i].SetActive(true);
                    continue;
                }

                weaponLevelParents[i].SetActive(false);
            }
        }
    }
}