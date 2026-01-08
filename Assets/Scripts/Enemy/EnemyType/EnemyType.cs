using UnityEngine;

namespace Enemy.EnemyType
{
    [CreateAssetMenu(menuName = "Enemy/EnemyType")]
    public class EnemyType : ScriptableObject
    {
        public int id;
        public GameObject prefab;
    }
}
