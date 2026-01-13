using Enemy.DanmakuPattern.Base;
using UnityEngine;

namespace Enemy.DanmakuPattern.ScriptableObject
{
    [CreateAssetMenu(menuName = "Enemy/DanmakuPattern")]
    public class DanmakuPatternDefinition : UnityEngine.ScriptableObject
    {
        public int id;
        public DanmakuPatternBase danmakuPattern;
    }
}
