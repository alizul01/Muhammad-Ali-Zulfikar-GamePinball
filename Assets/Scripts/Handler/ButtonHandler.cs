using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Handler
{
    [RequireComponent(typeof(AudioSource))]
    public class ButtonHandler : MonoBehaviour
    {
        public AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void QuitGame()
        {
            audioSource.Play();
            Debug.Log("Quitting game");
            Application.Quit();
        }
    
        public void GoToScene(string sceneName)
        {
            audioSource.Play();
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
        }
    }
}
