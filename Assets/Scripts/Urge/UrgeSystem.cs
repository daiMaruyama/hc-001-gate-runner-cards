using HighwayUrge.Core;
using UnityEngine;

namespace HighwayUrge.Urge
{
    /// <summary>
    /// 尿意メーターを管理する
    /// 時間経過による上昇・アイテムによる増減・演出トリガーを担う
    /// </summary>
    public class UrgeSystem : MonoBehaviour
    {
        const float MaxUrge = 100f;
        const float WarningThreshold = 75f;

        static UrgeSystem _instance;

        [Header("Settings")]
        [SerializeField] float _risePerSecond = 3f;

        float _currentUrge;

        public float CurrentUrge => _currentUrge;
        public float UrgePercent => _currentUrge / MaxUrge;

        // ---- Singleton ---- //
        public static UrgeSystem Instance
        {
            get
            {
                if (!_instance)
                {
                    var previous = FindFirstObjectByType<UrgeSystem>();
                    if (previous)
                    {
                        Debug.LogWarning("Initialized twice. Don't use UrgeSystem in the scene hierarchy.");
                        _instance = previous;
                    }
                    else
                    {
                        var go = new GameObject("UrgeSystem");
                        _instance = go.AddComponent<UrgeSystem>();
                        DontDestroyOnLoad(go);
                        go.hideFlags = HideFlags.HideInHierarchy;
                    }
                }
                return _instance;
            }
        }

        // ---- Core ---- //
        void Update()
        {
            if (GameManager.Instance.CurrentState != GameState.Playing) return;

            AddUrge(_risePerSecond * Time.deltaTime);
        }

        public void AddUrge(float amount)
        {
            _currentUrge = Mathf.Clamp(_currentUrge + amount, 0f, MaxUrge);

            if (_currentUrge >= MaxUrge)
                GameManager.Instance.GameOver();
            else if (_currentUrge >= WarningThreshold)
            {
                // TODO: 警告演出トリガー
            }
        }

        public void ReduceUrge(float amount)
        {
            _currentUrge = Mathf.Clamp(_currentUrge - amount, 0f, MaxUrge);
        }
    }
}
