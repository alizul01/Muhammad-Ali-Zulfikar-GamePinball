using System;
using System.Collections;
using Manager;
using UnityEngine;

namespace Controller
{
    public class SwitchController : MonoBehaviour
    {
        private enum SwitchState
        {
            Off,
            On,
            Blink
        }

        /// <summary>
        /// Materials[0] is the default material
        /// Materials[1] is the activated material
        /// </summary>
        public Material[] materials;
        
        public AudioSource audioSource;

        private SwitchState _state;

        private Renderer _renderer;
        public VFXManager vfxManager;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            Set(false);
        
            StartCoroutine(BlinkTimerStart(5));
        }

        private IEnumerator BlinkTimerStart(float time)
        {
            yield return new WaitForSeconds(time);
            StartCoroutine(Blink(2));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            ScoreManager.Instance.AddScore(5);
            vfxManager.PlayBumpVFX();
            audioSource.Play();
            Toggle();
        }

        private void Set(bool state)
        {
            if (state)
            {
                _renderer.material = materials[1];
                _state = SwitchState.On;
                StopAllCoroutines();
            }
            else
            {
                _renderer.material = materials[0];
                _state = SwitchState.Off;
                StartCoroutine(BlinkTimerStart(5));
            }
        }

        private void Toggle()
        {
            Set(_state != SwitchState.On);
        }

        private IEnumerator Blink(int times)
        {
            _state = SwitchState.Blink;
            for (var i = 0; i < times; i++)
            {
                _renderer.material = materials[1];
                yield return new WaitForSeconds(0.5f);
            
                _renderer.material = materials[0];
                yield return new WaitForSeconds(0.5f);
            }
        
            _state = SwitchState.Off;
            StartCoroutine(BlinkTimerStart(5));
        }
    }
}