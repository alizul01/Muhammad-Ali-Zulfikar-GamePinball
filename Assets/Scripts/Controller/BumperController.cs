using Manager;
using UnityEngine;

namespace Controller
{
    public class BumperController : MonoBehaviour
    {
        public Animator animator;
        public float multiplier = 1.5f;
        public VFXManager vfxManager;
    
        // Animator Hash
        private static readonly int Bump = Animator.StringToHash("Bump");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            var rb = other.gameObject.GetComponent<Rigidbody>();
        
            AudioManager.Instance.PlaySfx();
            vfxManager.PlayBumpVFX();
            ScoreManager.Instance.AddScore(1);
            animator.SetTrigger(Bump);
            rb.velocity *= multiplier;
        }
    }
}
