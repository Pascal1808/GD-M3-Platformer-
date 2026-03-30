using UnityEngine;

public class FPS : MonoBehaviour
{
    GUIStyle Style;

    void Start()
    {
        Style = new GUIStyle();
        Style.fontSize = 100;
        Style.normal.textColor = Color.red;
    }


    void OnGUI()
    {
        float fps = 1.0f / Time.deltaTime;
        GUI.Label(new Rect(10, 10, 100, 20), "FPS: " + Mathf.Round(fps), Style);
    }
}
