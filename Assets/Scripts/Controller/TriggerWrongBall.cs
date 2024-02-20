using System;
using Manager;
using UnityEngine;

namespace Controller
{
    public class TriggerWrongBall : MonoBehaviour
    {
        public HealthManager health;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            health.TakeDamage(1);
        }
    }
}
