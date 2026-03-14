using UnityEngine;

public class CrossHair : MonoBehaviour 
{
    [SerializeField] private float cameraOffset = 10f;
    void Start()
    {
        Cursor.visible = false; // マウスカーソルを非表示にする
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cameraOffset; // カメラからの距離を設定
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;
    }
}
