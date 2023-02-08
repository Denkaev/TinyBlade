using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSetka : MonoBehaviour
{
    Texture2D texture2D;
    public float camSpeed = 50;
    float camSize;
    void Start()
    {
        texture2D = new Texture2D(1, 1);
        Camera.main.orthographic = true;
        camSize = Camera.main.orthographicSize;
    }
    private void OnGUI()
    {
        GuiDrawSnap();
    }
    void GuiDrawSnap()
    {
        float step = Screen.height / 2 / Camera.main.orthographicSize;
        float corrX = Camera.main.transform.position.x - (int)Camera.main.transform.position.x;
        float corrY = Camera.main.transform.position.y - (int)Camera.main.transform.position.y;
        float x = Screen.width / 2 - corrX * step;

        for (float ix = step / 2; ix < Screen.width / 2 - 3 * step; ix += step)
        {
            GUI.DrawTexture(new Rect(x + ix, 1.5f * step, 1, Screen.height - 2 * step), texture2D);
            GUI.DrawTexture(new Rect(x - ix, 1.5f * step, 1, Screen.height - 2 * step), texture2D);
        }
        for (float iy = corrY * step + step * 1.5f; iy < Screen.height; iy += step)
        {
            GUI.DrawTexture(new Rect(step * 3.6f, iy, Screen.width - step * 7.2f, 1), texture2D);
        }
    }
}