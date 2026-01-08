using Enemy.MovePattern.Base;
using UnityEngine;

namespace Enemy.MovePattern.ScriptableObject
{
    [CreateAssetMenu(menuName = "Enemy/MovePattern")]
    public class MovePatternDefinition : UnityEngine.ScriptableObject
    {
        public int id;
        public MovePatternBase movePattern;
    }
}
