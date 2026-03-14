using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastTest : MonoBehaviour
{
    private int enemyLayerMask;
    LineRenderer lineRenderer;
    void Awake()
    {
        enemyLayerMask = LayerMask.GetMask("Enemy");
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f, enemyLayerMask))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 2f);
            }
            else
            {
                Debug.Log("No hit");
                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 2f);
            }
        }
    }
}
