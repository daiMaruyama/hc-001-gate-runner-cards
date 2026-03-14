using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;

public class RaycastFPS : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 100f;
    [SerializeField] private LayerMask _rayLayerMask;
    [SerializeField] EnumTest _currentState = EnumTest.Playing;
    private int _missCount = 0;
    private int _successCount = 0;
    [SerializeField] private int _maxMissCount = 5;
    [SerializeField] private int _maxSuccessCount = 10;
    [SerializeField] private TMPro.TextMeshProUGUI _statusText;

    void Update()
    {
        if (_currentState != EnumTest.Playing) return; // Playing状態以外は処理しない
    
        if (_missCount >= _maxMissCount)
        {
            _currentState = EnumTest.GameOver;
            _statusText.text = "Game Over! Too many misses.";
            return;
        }
        if (_successCount >= _maxSuccessCount)
        {
            _currentState = EnumTest.Clear;
            _statusText.text = "Clear! You win!";
            return;
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, _rayLayerMask))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);
            _successCount++;
            _statusText.text = "Hits: " + _successCount + " / Misses: " + _missCount;
            Debug.Log("Success Count: " + _successCount);
            hit.collider.gameObject.SetActive(false);
            StartCoroutine(Respawn(hit.collider.gameObject, 1f));
        }
        else
        {
            Debug.Log("Miss");
            _missCount++;
            _statusText.text = "Hits: " + _successCount + " / Misses: " + _missCount;
            Debug.Log("Miss Count: " + _missCount);
        }
    }

    IEnumerator Respawn(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        enemy.SetActive(true); // OnEnableでランダム位置に移動する
    }
}