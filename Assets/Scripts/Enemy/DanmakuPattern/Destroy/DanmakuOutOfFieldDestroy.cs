using UnityEngine;
using Utils;

namespace Enemy.DanmakuPattern.Destroy
{
    public class DanmakuOutOfFieldDestroy : MonoBehaviour
    {
        [SerializeField] private float margin = 1.0f;

        private void Update()
        {
            Vector3 pos = transform.position;

            if (pos.x < PlayField.Min.x - margin ||
                pos.x > PlayField.Max.x + margin ||
                pos.y < PlayField.Min.y - margin ||
                pos.y > PlayField.Max.y + margin)
            {
                Destroy(gameObject);
            }
        }
    }
}