using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu: MonoBehaviour
{
    //.SetActive(!Levels.activeSelf);
    public void Building()
    {
        Debug.Log("Building");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void Mercenaries()
    {
        Debug.Log("Mercenaries");
    }

}
