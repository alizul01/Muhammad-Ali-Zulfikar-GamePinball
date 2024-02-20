using UnityEngine;

namespace Controller
{
    public class BallController : MonoBehaviour
    {
        public float maxSpeed = 10f;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_rb.velocity.magnitude > maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * maxSpeed;
            }
        }
    }
}
