using UnityEngine;

public class Rotate_test : MonoBehaviour
{
    [SerializeField] Vector3 center = Vector3.zero;
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] float period = 1;

    void FixedUpdate()
    {
        transform.RotateAround(center, axis, 360 / period * Time.fixedDeltaTime);
    }
}
