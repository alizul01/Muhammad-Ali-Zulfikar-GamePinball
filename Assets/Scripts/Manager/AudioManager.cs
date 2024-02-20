using System;
using UnityEngine;

namespace Manager
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        public AudioClip[] audioClips;
        public AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            PlayBGM();
        }
        
        private void PlayBGM()
        {
            audioSource.clip = audioClips[0];
            audioSource.loop = true;
            audioSource.Play();
        }
        
        public void PlaySfx()
        {
            audioSource.PlayOneShot(audioClips[1]);
        }
    }
}
