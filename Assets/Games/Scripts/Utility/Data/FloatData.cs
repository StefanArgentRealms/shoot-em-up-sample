using UnityEngine;

namespace Games.Scripts.Utility.Data
{
    [CreateAssetMenu(menuName = "Shoot Em Up/Data/Float", fileName = "FloatData", order = 0)]
    public class FloatData : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value => value;
    }
}