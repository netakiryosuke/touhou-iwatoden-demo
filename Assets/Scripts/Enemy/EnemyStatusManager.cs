using UnityEngine;

namespace Enemy
{
    public class EnemyStatusManager : MonoBehaviour
    {
        [SerializeField] private AudioClip damageSE;
        [SerializeField] private AudioClip lowHpDamageSE;
        [SerializeField] private AudioClip deathSE;
        [SerializeField] private float lowHpThreshold = 0.3f;
        private float _maxHp;
        private float _hp;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Initialize(float hp)
        {
            _maxHp = hp;
            _hp = hp;
        }
        
        public void TakeDamage(float damage)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                Die();
                return;
            }
            
            PlayDamageSE();
        }
        
        private void PlayDamageSE()
        {
            float hpRate = _hp / _maxHp;

            if (hpRate <= lowHpThreshold)
            {
                _audioSource.PlayOneShot(lowHpDamageSE);
            }
            else
            {
                _audioSource.PlayOneShot(damageSE);
            }
        }
        
        private void Die()
        {
            AudioSource.PlayClipAtPoint(deathSE, transform.position);
            Destroy(gameObject);
        }
    }
}
