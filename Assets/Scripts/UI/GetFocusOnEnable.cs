using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class GetFocusOnEnable : MonoBehaviour
    {
        private void Start()
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
