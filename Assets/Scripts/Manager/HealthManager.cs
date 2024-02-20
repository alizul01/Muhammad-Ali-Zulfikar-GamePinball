using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Manager
{
    public class HealthManager : MonoBehaviour
    {
        public CanvasGroup gameOverCanvas;
        public int lives = 3;
        public Heart[] hearts;
        public Transform spawnPoint;
        public GameObject ballPrefab;
        public AudioSource audioSource;
        public AudioClip[] audioClips;

        private void Awake()
        {
            hearts = transform.GetComponentsInChildren<Heart>();
            audioSource = GetComponent<AudioSource>();
            foreach (var item in hearts)
            {
                item.heartImage.sprite = item.heartSprites[0];
            }
        }

        public void TakeDamage(int damage)
        {
            audioSource.PlayOneShot(audioClips[0]);
            lives -= damage;
            for (var i = 0; i < hearts.Length; i++)
            {
                if (lives > i)
                {
                    continue;
                }
                hearts[i].heartImage.sprite = hearts[i].heartSprites[1];
            }
            
            if (lives <= 0)
            {
                audioSource.PlayOneShot(audioClips[1]);
                Die();
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Ball"));
                Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    
        public void Die()
        {
            gameOverCanvas.gameObject.SetActive(true);
            gameOverCanvas.alpha = 1;
            gameOverCanvas.interactable = true;
            gameOverCanvas.blocksRaycasts = true;
        }
    }
}
