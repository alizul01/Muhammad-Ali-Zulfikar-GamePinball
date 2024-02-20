using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ButtonTextAnimation : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        public CanvasGroup indicator;
        public Color selectedColor;
        protected Color DefaultColor;
        protected TMP_Text Text;

        private void Awake()
        {
            Text = GetComponent<TMP_Text>();
            DefaultColor = Text.color;

            if (EventSystem.current.currentSelectedGameObject == gameObject)
            {
                OnSelect(null);
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            StartCoroutine(FlickerText());
        }

        public void OnDeselect(BaseEventData eventData)
        {
            indicator.alpha = 0;
            Text.color = DefaultColor;
            StopAllCoroutines();
        }

        private IEnumerator FlickerText()
        {
            while (true)
            {
                var flickerAlpha = Random.Range(0.5f, 1f);
                indicator.alpha = flickerAlpha;
                Text.color = selectedColor;

                yield return new WaitForSecondsRealtime(0.3f); 

                indicator.alpha = 0;
                Text.color = DefaultColor;

                yield return new WaitForSecondsRealtime(0.3f);
            }
        }
    }
}