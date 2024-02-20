using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Heart: MonoBehaviour
    {
        public Sprite[] heartSprites;
        public Image heartImage;

        private void Awake()
        {
            heartImage = GetComponent<Image>();
        }
    }
}