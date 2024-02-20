using System;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class CameraController : MonoBehaviour
    {
        public Transform dummyTarget;
        public Transform target;
        
        public float offset = 10f;
        public float returnTime;
        public float followSpeed;
        public float length;

        public bool isHasTarget => target != null;

        private Vector3 _defaultPosition;

        private void Awake()
        {
            _defaultPosition = transform.position;
            target = null;
        }
        
        private void LateUpdate()
        {
            if (!isHasTarget) return;
            
            var targetToCameraDirection = transform.rotation * -Vector3.forward;
            var targetPosition = target.position + (targetToCameraDirection * length);
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }

        public void FollowAtTarget(Transform targetTransform, float targetLength)
        {
            StopAllCoroutines();
            target = targetTransform;
            length = targetLength;
        }
        
        public void ReturnToDefaultPosition()
        {
            target = null;
            StopAllCoroutines();
            StartCoroutine(MovePosition(_defaultPosition, returnTime));
        }

        private IEnumerator MovePosition(Vector3 targetPosition, float time)
        {
            float timer = 0;
            
            while (timer < time)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Mathf.SmoothStep(0, 1, timer / time));
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            transform.position = targetPosition;
        }
    }
}
