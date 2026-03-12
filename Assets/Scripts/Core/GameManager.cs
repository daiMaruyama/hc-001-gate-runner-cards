using System;
using UnityEngine;

namespace HighwayUrge.Core
{
    /// <summary>
    /// ゲーム全体を管理するシングルトン
    /// GameState の管理・画面遷移・ステージ開始/終了を担う
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        // DONE: Singleton 実装
        // DONE: GameState フィールド
        // TODO: Awake() で Singleton 初期化
        // DONE: StartGame()
        // DONE: ClearGame()
        // DONE: GameOver()
        // DONE: ChangeState(GameState newState)
        static GameManager _instance;
        GameState _currentState = GameState.Title;
        public GameState CurrentState => _currentState;

        public static GameManager Instance
        {
            get
            {
                if (!_instance)
                {
                    var previous = FindFirstObjectByType<GameManager>();
                    if (previous)
                    {
                        Debug.LogWarning("Initialized twice. Don't use GameManager in the scene hierarchy.");
                        _instance = previous;
                    }
                    else
                    {
                        var go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                        DontDestroyOnLoad(go);
                        go.hideFlags = HideFlags.HideInHierarchy;
                    }
                }
                return _instance;
            }
        }

        public void StartGame()
        {
            ChangeState(GameState.Playing);
        }
        public void ClearGame()
        {
            ChangeState(GameState.Clear);
        }
        public void GameOver()
        {
            ChangeState(GameState.GameOver);
        }
        void ChangeState(GameState newState)
        {
            _currentState = newState;
        }
    }


    /// <summary>
    /// ゲームの状態を表す列挙型
    /// </summary>
    public enum GameState
    {
        Title,
        Playing,
        Clear,
        GameOver
    }
}

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score = 0;
    public event Action<int> OnScoreChanged;

    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreChanged?.Invoke(_score);
    }
}

public class  DisplayUI : MonoBehaviour
{
    [SerializeField] ScoreManager SM;

    void OnEnable()
    {
        SM.OnScoreChanged += UpdateScoreDisplay;
    }

    void OnDisable()
    {
        SM.OnScoreChanged -= UpdateScoreDisplay;
    }

    void UpdateScoreDisplay(int newScore)
    {
        // スコア表示を更新する処理
        Debug.Log($"Score Updated: {newScore}");
    }
}

public class ScoreUpdate : MonoBehaviour
{
    int _highScore = 0;
    [SerializeField] ScoreManager SM;

    private void OnEnable()
    {
        SM.OnScoreChanged += CheckHighScore;
    }

    void OnDisable()
    {
        SM.OnScoreChanged -= CheckHighScore;
    }

    void CheckHighScore(int newScore)
    {
        if (newScore > _highScore)
        {
            _highScore = newScore;
            Debug.Log($"New High Score: {_highScore}");
        }
    }
}
