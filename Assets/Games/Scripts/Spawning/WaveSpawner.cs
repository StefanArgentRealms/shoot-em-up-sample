using System;
using System.Collections;
using Games.Scripts.Input.AI;
using Games.Scripts.Movement.Data;
using UnityEngine;

namespace Games.Scripts.Spawning
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Transform wavesParent;
        [SerializeField] private Wave[] waves;

        private void OnEnable()
        {
            foreach (var wave in waves)
                StartCoroutine(SpawnDelayCoroutine(wave));
        }

        private void OnDisable() => StopAllCoroutines();

        //Normally I would use UniTask and run this with async/await and cancellationTokens instead of using coroutines.
        //Sticking with coroutines here to keep things simple.
        private IEnumerator SpawnDelayCoroutine(Wave wave)
        {
            yield return new WaitForSeconds(wave.SpawnDelay);
            var spawnedWave = Instantiate(wave.Prefab, wavesParent.position, wavesParent.rotation, wavesParent);

            //Looking through all children for simplicities sake.
            //A more efficient approach would be to have a wave component that knows about all its children and that can pass along the movement data to them.
            var moveAIs = spawnedWave.GetComponentsInChildren<MoveByCurveSetAI>();

            foreach (var ai in moveAIs)
                ai.SetCurveSet(wave.MovementCurveSet);
        }

        [Serializable]
        private class Wave
        {
            [SerializeField] private GameObject prefab;
            [SerializeField] private float spawnDelay;
            [SerializeField] private MovementCurveSet movementCurveSet;

            public GameObject Prefab => prefab;
            public float SpawnDelay => spawnDelay;
            public MovementCurveSet MovementCurveSet => movementCurveSet;
        }
    }
}