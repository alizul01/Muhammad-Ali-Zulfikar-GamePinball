using UnityEngine;

namespace Controller
{
    public class TriggerZoomInController : MonoBehaviour
    {
        public CameraController cameraController;
        public float length;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            cameraController.FollowAtTarget(other.transform, length);
        }
    }
}
