using UnityEngine;

namespace Manager
{
    public class VFXManager : MonoBehaviour
    {
        public ParticleSystem bumpVFX;

        private void Awake()
        {
            bumpVFX = GetComponent<ParticleSystem>();
        }

        public void PlayBumpVFX()
        {
            bumpVFX.Play();
        }
    }
}
