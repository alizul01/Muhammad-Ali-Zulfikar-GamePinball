using System;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class LauncherController : MonoBehaviour
    {
        public KeyCode input;
    
        public float maxForce = 10f;
        public float maxTimeHold = 2f;
    
        private bool _isHolding;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        private void OnCollisionStay(Collision other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            ReadInput(other.gameObject);
        }

        private void ReadInput(GameObject ball)
        {
            if (Input.GetKey(input) && !_isHolding)
            {
                StartCoroutine(StartHold(ball));
            }
        }

        private IEnumerator StartHold(GameObject ball)
        {
            var defaultColor = _renderer.material.color;
            _isHolding = true;
            var force = 0f;
            var time = 0.0f;
        
            while (Input.GetKey(input))
            {
                _renderer.material.color = Color.red;
                force = Mathf.Lerp(0, maxForce, time / maxTimeHold);
                yield return new WaitForEndOfFrame();
                time += Time.deltaTime;
            }
            ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
            _isHolding = false;
            _renderer.material.color = defaultColor;
        }
    }
}
