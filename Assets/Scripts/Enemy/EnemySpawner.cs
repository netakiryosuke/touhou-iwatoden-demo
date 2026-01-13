using Enemy.DanmakuPattern.Base;
using Enemy.DanmakuPattern.ScriptableObject;
using Enemy.EnemyType;
using Enemy.MovePattern.Base;
using Enemy.MovePattern.ScriptableObject;
using Enemy.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private TextAsset enemyCsv;
        [SerializeField] private EnemyTypeMaster enemyTypeMaster;
        [SerializeField] private MovePatternMaster movePatternMaster;
        [SerializeField] private DanmakuPatternMaster danmakuPatternMaster;

        private Queue<EnemyData> _queue;
        private float _timer;

        private void Start()
        {
            _queue = CsvLoader.Load(enemyCsv);
        }

        private void Update()
        {
            if (_queue.Count == 0) return;

            _timer += Time.deltaTime;

            EnemyData next = _queue.Peek();
            if (_timer >= next.spawnTime)
            {
                Spawn(next);
                _queue.Dequeue();
            }
        }

        private void Spawn(EnemyData data)
        {
            // 敵生成
            EnemyType.EnemyType enemyType = enemyTypeMaster.Get(data.enemyId);
            GameObject enemy = Instantiate(enemyType.prefab, data.position, Quaternion.identity);

            // HP初期化
            // enemy.GetComponent<EnemyStatusManager>()
            //     .Initialize(data.hp);

            // 移動付与
            AttachMovePattern(enemy, movePatternMaster.Get(data.movePatternId));

            // 弾幕付与
            AttachDanmakuPattern(enemy, danmakuPatternMaster.Get(data.danmakuPatternId));
        }

        private void AttachMovePattern(GameObject enemy, MovePatternDefinition movePatternDefinition)
        {
            Type type = movePatternDefinition.movePattern.GetType();
            MovePatternBase pattern = enemy.AddComponent(type) as MovePatternBase;
            pattern.Initialize();
        }
        
        private void AttachDanmakuPattern(GameObject enemy, DanmakuPatternDefinition danmakuPatternDefinition)
        {
            Type type = danmakuPatternDefinition.danmakuPattern.GetType();
            DanmakuPatternBase pattern = enemy.AddComponent(type) as DanmakuPatternBase;
            pattern.Initialize(danmakuPatternDefinition.danmakuPrefab);
        }
    }
}
