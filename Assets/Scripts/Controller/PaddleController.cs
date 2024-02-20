using UnityEngine;

namespace Controller
{
    public class PaddleController : MonoBehaviour
    {
        public KeyCode input;
        public HingeJoint hinge;

        private float _targetReleased;
        private float _targetPressed;

        private void Awake()
        {
            hinge = GetComponent<HingeJoint>();
            var limits = hinge.limits;
        
            _targetReleased = limits.min;
            _targetPressed = limits.max;
        }

        private void Update()
        {
            ReadInput();
        }

        private void ReadInput()
        {
            var jointSpring = hinge.spring;
            jointSpring.targetPosition = Input.GetKey(input) ? _targetPressed : _targetReleased;
            hinge.spring = jointSpring;
        }
    }
}
