using UnityEngine;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        public int score;
    
        private void Awake()
        {
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
            score = 0;
        }
    
        public void AddScore(int value)
        {
            score += value;
        }
    
        public void ResetScore()
        {
            score = 0;
        }
    }
}
