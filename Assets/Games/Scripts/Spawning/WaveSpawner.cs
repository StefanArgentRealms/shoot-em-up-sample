using System;
using System.Collections;
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
            Instantiate(wave.Prefab, wavesParent.position, wavesParent.rotation, wavesParent);
        }

        [Serializable]
        private class Wave
        {
            [SerializeField] private GameObject prefab;
            [SerializeField] private float spawnDelay;

            public GameObject Prefab => prefab;
            public float SpawnDelay => spawnDelay;
        }
    }
}