using Enemy.DanmakuPattern.Base;
using Enemy.DanmakuPattern.DanmakuMove;
using UnityEngine;

namespace Enemy.DanmakuPattern
{
    public class DanmakuPattern0 : DanmakuPatternBase
    {
        private GameObject _danmakuPrefab;
        private float _timer;
        private float _interval;
        
        public override void Initialize(GameObject danmakuPrefab)
        {
            _danmakuPrefab = danmakuPrefab;
            _interval = 0.5f;
        }
        
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _interval)
            {
                Fire();
                _timer = 0f;
            }
        }

        private void Fire()
        {
            GameObject danmaku = Instantiate(
                _danmakuPrefab,
                transform.position,
                Quaternion.identity
            );

            danmaku.AddComponent<DanmakuMove0>();
        }
    }
}
