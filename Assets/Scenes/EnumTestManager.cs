using UnityEngine;
using UnityEngine.Events;

public class EnumTestManager : MonoBehaviour
{
    [SerializeField] private EnumTest currentState;
    [SerializeField] private UnityEvent _onGameStart;
    [SerializeField] private AnimationCurve _easingCurve;
    [SerializeField] private Gradient _damageGradient;
    [SerializeField] private Color _bulletColor = Color.red;
    private void Awake() // Startとどっち？
    {
        Debug.Log("Current State: " + currentState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 入力はInputSystemの場合、差し替えてください
        {
            switch (currentState)
            {
                case EnumTest.MainMenu:
                    currentState = EnumTest.Playing;
                    break;
                case EnumTest.Playing:
                    currentState = EnumTest.Paused;
                    break;
                case EnumTest.Paused:
                    currentState = EnumTest.Playing;
                    break;
                case EnumTest.GameOver:
                    currentState = EnumTest.MainMenu;
                    break;
            }
            Debug.Log("Current State: " + currentState);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentState = EnumTest.MainMenu;
            Debug.Log("Current State: " + currentState);
        }
    }
}
