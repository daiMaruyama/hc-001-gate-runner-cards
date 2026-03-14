using Unity.VisualScripting;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    GameObject core;
    Vector3 center;
    Vector3 axis;
    float angularVelocity;
    float deltaAcceleration = 0.2f;
    float angularAcceleration;
    float t = 0.998f;
    [SerializeField] string tagName = "Head";
    int count = 0;
    void Start()
    {
        core = GameObject.Find(tagName);
        center = core.transform.position;
        axis = Vector3.forward;

        this.transform.up = core.transform.position - this.transform.position;
    }

    void FixedUpdate()
    {
        if (count == 0)
        {
            angularVelocity = 0f;
            count++;
            angularAcceleration = -deltaAcceleration;
            angularVelocity += angularAcceleration;
            angularVelocity *= t;
            transform.RotateAround(center, axis, angularVelocity);
        }

        if (Mathf.Abs(angularVelocity) < 0.001f)
        {
            angularVelocity = 0f;
            return;
        }

        if (transform.position.x - core.transform.position.x > 0f)
        {
            angularAcceleration = -deltaAcceleration;
        }
        else
        {
            angularAcceleration = deltaAcceleration;
        }
        angularVelocity += angularAcceleration;
        angularVelocity *= t;
        transform.RotateAround(center, axis, angularVelocity);
    }
}
