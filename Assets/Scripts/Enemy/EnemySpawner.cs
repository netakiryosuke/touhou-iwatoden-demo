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
        // [SerializeField] private DanmakuPatternMaster danmakuPatternMaster;

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
            if (_timer >= next.SpawnTime)
            {
                Spawn(next);
                _queue.Dequeue();
            }
        }

        private void Spawn(EnemyData data)
        {
            // 敵生成
            EnemyType enemyType = enemyTypeMaster.Get(data.EnemyId);
            GameObject enemy = Instantiate(enemyType.prefab, data.Position, Quaternion.identity);

            // HP初期化
            // enemy.GetComponent<EnemyStatusManager>()
            //     .Initialize(data.hp);

            // 移動付与
            AttachPattern(enemy, movePatternMaster.Get(data.MovePatternId));

            // 弾幕付与（後回しでOK）
            // AttachPattern(enemy, danmakuPatternMaster.Get(data.danmakuPatternId));
        }

        private void AttachPattern(GameObject enemy, MovePatternDefinition movePatternDefinition)
        {
            Type type = movePatternDefinition.script.GetClass();
            MovePatternBase pattern = enemy.AddComponent(type) as MovePatternBase;
            pattern.Initialize();
        }
    }

}