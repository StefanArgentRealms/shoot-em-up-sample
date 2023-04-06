using System;
using System.Collections;
using Games.Scripts.Input.Commands.Data;
using Games.Scripts.Movement.Data;
using UnityEngine;

namespace Games.Scripts.Input.AI
{
    public class MoveByCurveSetAI : MonoBehaviour
    {
        [SerializeField] private Transform forwardReferenceTransform;
        [SerializeField] private CommandContainer commandContainer;
        [SerializeField] private MovementCurveSet curveSet;

        public Action OnMovementComplete = default;

        private void OnEnable()
        {
            if (curveSet == null)
                return;

            StartCoroutine(Move());
        }

        private void OnDisable() => StopAllCoroutines();

        public void SetCurveSet(MovementCurveSet newCurveSet) => curveSet = newCurveSet;

        public void RestartMovement()
        {
            StopAllCoroutines();
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            var progress = 0f;

            while (progress < 1)
            {
                progress += Time.deltaTime / curveSet.MovementDuration;
                commandContainer.Move = forwardReferenceTransform.rotation * curveSet.EvaluateAtProgress(progress);
                yield return null;
            }

            OnMovementComplete?.Invoke();
        }
    }
}