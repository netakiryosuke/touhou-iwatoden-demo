using Enemy.DanmakuPattern.DanmakuMove.Base;
using UnityEngine;

namespace Enemy.DanmakuPattern.DanmakuMove
{
    public class DanmakuMove0 : DanmakuMoveBase
    {
        private void Update()
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
    }
}
