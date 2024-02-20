using TMPro;
using UnityEngine;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        public TMP_Text scoreText;
    
        public void FixedUpdate()
        {
            scoreText.text = ScoreManager.Instance.score.ToString();
        }
    }
}
