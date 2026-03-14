using UnityEngine;
using System.Diagnostics;
 
/// <summary>
/// CubeをPrefab化して_enemyPrefabにアサイン。空のGameObjectにアタッチ。
/// _usePoolを切り替えてConsoleの処理時間を比較。
/// </summary>
public class OverHead : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private bool _usePool = false;
    [SerializeField] private int _count = 1000;
 
    void Start()
    {
        var sw = new Stopwatch();
 
        if (_usePool)
        {
            // 最初に1つ生成
            GameObject enemy = Instantiate(_enemyPrefab, RandomPos(), Quaternion.identity);
 
            sw.Start();
            for (int i = 0; i < _count; i++)
            {
                enemy.SetActive(false);
                enemy.transform.position = RandomPos();
                enemy.SetActive(true);
            }
            sw.Stop();
 
            UnityEngine.Debug.Log($"[SetActive] {_count}回: {sw.ElapsedMilliseconds} ms");
        }
        else
        {
            GameObject enemy = Instantiate(_enemyPrefab, RandomPos(), Quaternion.identity);
 
            sw.Start();
            for (int i = 0; i < _count; i++)
            {
                Destroy(enemy);
                enemy = Instantiate(_enemyPrefab, RandomPos(), Quaternion.identity);
            }
            sw.Stop();
 
            UnityEngine.Debug.Log($"[Destroy/Instantiate] {_count}回: {sw.ElapsedMilliseconds} ms");
        }
    }
 
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
    }
}