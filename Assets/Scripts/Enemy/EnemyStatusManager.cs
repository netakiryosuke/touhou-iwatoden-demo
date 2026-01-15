using UnityEngine;

namespace Enemy
{
    public class EnemyStatusManager : MonoBehaviour
    {
        private float _hp;

        public void Initialize(float hp)
        {
            _hp = hp;
        }
        
        public void TakeDamage(float damage)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}