using UnityEngine;

namespace Controller
{
    public class TriggerZoomOutController : MonoBehaviour
    {
        public CameraController cameraController;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            cameraController.ReturnToDefaultPosition();
        }
    }
}
