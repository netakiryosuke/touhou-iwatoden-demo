using Enemy.MovePattern.Base;
using UnityEngine;

namespace Enemy.MovePattern
{
    public class MovePattern0 : MovePatternBase
    {
        private float _speed;
        public override void Initialize()
        {
            _speed = 0.01f;
        }
        
        private void Update()
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }
    }
}
