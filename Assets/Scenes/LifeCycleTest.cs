using UnityEngine;
using System.Collections;

public class LifeCycleTest : MonoBehaviour
{
    private bool _updateCalled = false;
    private bool _lateUpdateCalled = false;
    private bool _fixedUpdateCalled = false;
    [SerializeField] private float _destroyDelay = 1f;

    private void Awake()
    {
        Debug.Log("<color=red>Awake</color>");
    }

    private void Start()
    {
        Debug.Log("<color=green>Start</color>");
        StartCoroutine(DestroyAfterDelay(_destroyDelay));
    }

    private void OnEnable()
    {
        Debug.Log("<color=blue>OnEnable</color>");
    }

    private void OnDisable()
    {
        Debug.Log("<color=yellow>OnDisable</color>");
    }

    private void OnDestroy()
    {
        Debug.Log("<color=magenta>OnDestroy</color>");
    }

    private void Update()
    {
        if (!_updateCalled)
            Debug.Log("<color=cyan>Update</color>");
        _updateCalled = true;
    }

    private void LateUpdate()
    {
        if (!_lateUpdateCalled)
            Debug.Log("<color=cyan>LateUpdate</color>");
        _lateUpdateCalled = true;
    }

    private void FixedUpdate()
    {
        if (!_fixedUpdateCalled)
            Debug.Log("<color=cyan>FixedUpdate</color>");
        _fixedUpdateCalled = true;
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
