using System.Collections.Generic;
using UnityEngine;

namespace Enemy.MovePattern.ScriptableObject
{
    [CreateAssetMenu(menuName = "Enemy/MovePatternMaster")]
    public class MovePatternMaster : UnityEngine.ScriptableObject
    {
        public List<MovePatternDefinition> patterns;

        public MovePatternDefinition Get(int id)
        {
            return patterns.Find(x => x.id == id);
        }
    }
}
