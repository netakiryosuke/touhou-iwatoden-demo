using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Enemy/EnemyTypeMaster")]
    public class EnemyTypeMaster : ScriptableObject
    {
        public List<EnemyType> enemyTypes;

        public EnemyType Get(int id)
        {
            return enemyTypes.Find(x => x.id == id);
        }
    }

}