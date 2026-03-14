// EnemyPoolSample.cs（敵側はシンプルに）
using UnityEngine;

public class EnemyPoolSample : MonoBehaviour
{
    void OnEnable()
    {
        transform.position = new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
    }
}