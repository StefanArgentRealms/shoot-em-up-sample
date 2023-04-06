using System.Collections;
using UnityEngine;

namespace Games.Scripts.Utility
{
    public class SelfDestructTimer : MonoBehaviour
    {
        [SerializeField] private float selfDestructTime = 10f;

        private void OnEnable() => StartCoroutine(DelaySelfDestruction());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator DelaySelfDestruction()
        {
            yield return new WaitForSeconds(selfDestructTime);
            Destroy(gameObject);
        }
    }
}