using HighwayUrge.Core;
using HighwayUrge.Urge;
using UnityEngine;

public class DebugStarter : MonoBehaviour
{
    GUIStyle _style;

    void Start()
    {
        GameManager.Instance.StartGame();
        Debug.Log("DebugStarter: Game Started");
    }

    void OnGUI()
    {
        if (_style == null)
        {
            _style = new GUIStyle(GUI.skin.label);
            _style.fontSize = 24;
            _style.normal.textColor = Color.yellow;
        }

        GUI.Label(new Rect(10, 10, 400, 40),
            $"Urge: {UrgeSystem.Instance.CurrentUrge:F1}%", _style);
    }
}
