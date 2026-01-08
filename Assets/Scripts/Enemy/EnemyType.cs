using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Enemy/EnemyType")]
    public class EnemyType : ScriptableObject
    {
        public int id;
        public GameObject prefab;
    }
}