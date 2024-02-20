using System;
using Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Controller
{
    public class TriggerRampController: MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            ScoreManager.Instance.AddScore(20);
        }
    }
}