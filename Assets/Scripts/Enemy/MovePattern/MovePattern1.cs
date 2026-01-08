using Enemy.MovePattern.Base;
using UnityEngine;

namespace Enemy.MovePattern
{
    public class MovePattern1 : MovePatternBase
    {
        public override void Initialize()
        {
            transform.position = Vector3.down * Time.deltaTime;
        }
    }
}