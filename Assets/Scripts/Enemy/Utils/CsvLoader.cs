using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Utils
{
    public class CsvLoader
    {
        public static Queue<EnemyData> Load(TextAsset csv)
        {
            Queue<EnemyData> enemyDataQueue = new();

            string[] lines = csv.text.Split(
                new[] { '\r', '\n' },
                System.StringSplitOptions.RemoveEmptyEntries
            );

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');
                enemyDataQueue.Enqueue(
                    new EnemyData
                    {
                        SpawnTime = float.Parse(columns[0]),
                        Position = new Vector3(float.Parse(columns[1]), float.Parse(columns[2]), 0),
                        EnemyId = int.Parse(columns[3]),
                        MovePatternId = int.Parse(columns[4]),
                        DanmakuPatternId = int.Parse(columns[5]),
                        Hp = float.Parse(columns[6]),
                    }
                );
            }

            return enemyDataQueue;
        }
    }
}