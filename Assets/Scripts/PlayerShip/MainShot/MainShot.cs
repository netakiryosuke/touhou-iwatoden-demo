using Enemy;
using UnityEngine;

namespace PlayerShip.MainShot
{
    public class MainShot : MonoBehaviour
    {
        [SerializeField] private float mainShotSpeed = 70f;
        [SerializeField] private int damage = 1;
        
        private void Update()
        {
            transform.position += Vector3.up * (Time.deltaTime * mainShotSpeed);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return;

            if (other.TryGetComponent<EnemyStatusManager>(out var enemyStatusManager))
            {
                enemyStatusManager.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
