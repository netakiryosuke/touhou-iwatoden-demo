using UnityEngine;
using Utils;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int initialLife = 3;
    private int _life;

    private void Awake()
    {
        Instance = this;
        _life = initialLife;
    }

    public void OnPlayerHit()
    {
        _life--;

        DanmakuClearer.ClearAll();

        if (_life < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // TODO
        Debug.Log("Game Over");
    }
}
