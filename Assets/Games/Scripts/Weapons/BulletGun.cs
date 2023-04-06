using UnityEngine;

namespace Games.Scripts.Weapons
{
    public class BulletGun : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float timeBetweenShots;
    }
}