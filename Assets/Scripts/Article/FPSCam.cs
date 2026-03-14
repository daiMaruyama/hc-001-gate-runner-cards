using UnityEngine;

public class FPSCam : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 300f;
    private float _xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 上下は角度を蓄積してClampで制限
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        // 上下はlocalRotationで直接セット
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // 左右は親オブジェクトを回す
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}