using System.Collections.Generic;
using UnityEngine;

namespace Enemy.DanmakuPattern.ScriptableObject
{
    [CreateAssetMenu(menuName = "Enemy/DanmakuPatternMaster")]
    public class DanmakuPatternMaster : UnityEngine.ScriptableObject
    {
        public List<DanmakuPatternDefinition> patterns;

        public DanmakuPatternDefinition Get(int id)
        {
            return patterns.Find(x => x.id == id);
        }
    }
}
