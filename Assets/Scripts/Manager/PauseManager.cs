using UnityEngine;
using UnityEngine.EventSystems;

namespace Manager
{
    public class PauseManager : MonoBehaviour
    {
        public static bool GameIsPaused;
        public GameObject pauseMenuUI;
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                pauseMenuUI.SetActive(true);
            }
        }
        
        public void Resume()
        {
            EventSystem.current.sendNavigationEvents = false;
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
        }
        
        public static void Pause()
        {
            EventSystem.current.sendNavigationEvents = true;
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        
        
    }
}