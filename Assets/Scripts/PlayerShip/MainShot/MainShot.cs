using System;
using UnityEngine;

namespace PlayerShip.MainShot
{
    public class MainShot : MonoBehaviour
    {
        [SerializeField] private float mainShotSpeed = 70f;
        
        private void Update()
        {
            transform.position += Vector3.up * (Time.deltaTime * mainShotSpeed);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
