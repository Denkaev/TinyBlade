using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu: MonoBehaviour
{
    public List<GameObject> BuildsButtons = new List<GameObject>();
    public List<GameObject> MercenariesButtons = new List<GameObject>();
    //.SetActive(!Levels.activeSelf);
    //Ќужно вынести листы куда-то в общее место
    public void Building()
    {
        BuildsButtons.ForEach(b => b.SetActive(true));
        MercenariesButtons.ForEach(b => b.SetActive(false));
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
        BuildsButtons.ForEach(b => b.SetActive(false));
        MercenariesButtons.ForEach(b => b.SetActive(true));
    }

    public void Invert(List<GameObject> Buttons)
    {
        Buttons.ForEach(b => b.SetActive(!b.activeSelf));
    }
}
