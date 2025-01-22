using UnityEngine;
using UnityEngine.UI;

public class LogPanel : MonoBehaviour
{
    protected static LogPanel Current;

    public Text logLabel;

    void Awake()
    {
        Current = this;
    }

    public static void Write(string message)
    {
        Current.logLabel.text = message;
    }
}
