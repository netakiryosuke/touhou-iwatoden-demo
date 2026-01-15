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
    }
}