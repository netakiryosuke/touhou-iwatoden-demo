using UnityEngine;

namespace PlayerShip.MainShot
{
    public class MainShot : MonoBehaviour
    {
        [SerializeField] private float mainShotSpeed = 70f;
        
        public void Update()
        {
            transform.position += Vector3.up * (Time.deltaTime * mainShotSpeed);
        }
    }
}