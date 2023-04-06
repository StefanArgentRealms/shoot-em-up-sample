using Games.Scripts.Input.Commands.Data;
using Games.Scripts.Utility.Data;
using UnityEngine;

namespace Games.Scripts.Weapons
{
    public class BulletGun : MonoBehaviour
    {
        [SerializeField] private CommandContainer commandContainer;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private FloatData timeBetweenShots;

        private float timeOfLastShot;
        private float EarliestTimeOfNextShot => timeOfLastShot + timeBetweenShots.Value;

        private void Update() => CheckShooting();

        private void CheckShooting()
        {
            if (!commandContainer.Shoot)
                return;

            if (Time.time < EarliestTimeOfNextShot)
                return;

            Shoot();
        }

        private void Shoot()
        {
            //Typically object-pooling would be used in situations like this, where we create and destroy a lot of the same objects rapidly.
            //I'm leaving it out of this sample for simplicity.
            //If maximum performance is required then instead of using GameObjects I would look at making a Shoot-Em-Up using Unity DOTS.
            //Having each bullet be a lightweight entity instead of a GameObject, and running as many system as possible in parallel through ECS and the Unity Jobs system would increase performance dramatically.
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            timeOfLastShot = Time.time;
        }
    }
}