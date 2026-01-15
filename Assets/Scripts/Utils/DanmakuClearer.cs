using UnityEngine;

namespace Utils
{
    public static class DanmakuClearer
    {
        public static void ClearAll()
        {
            foreach (var danmaku in GameObject.FindGameObjectsWithTag("EnemyDanmaku"))
            {
                Object.Destroy(danmaku);
            }
        }
    }
}
