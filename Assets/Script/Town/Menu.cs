using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu: MonoBehaviour
{

    public Listes listes;
    //public List<GameObject> BuildsButtons = new List<GameObject>();
    //public List<GameObject> MercenariesButtons = new List<GameObject>();
    //.SetActive(!Levels.activeSelf);
    public void Building()
    {

        listes.BuildsButtons.ForEach(b => b.SetActive(true));
        listes.MercenariesButtons.ForEach(b => b.SetActive(false));
        //BuildsButtons.ForEach(b => b.SetActive(true));
        //MercenariesButtons.ForEach(b => b.SetActive(false));
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
        listes.BuildsButtons.ForEach(b => b.SetActive(false));
        listes.MercenariesButtons.ForEach(b => b.SetActive(true));

        //BuildsButtons.ForEach(b => b.SetActive(false));
        //MercenariesButtons.ForEach(b => b.SetActive(true));
    }

    public void Invert(List<GameObject> Buttons)
    {
        Buttons.ForEach(b => b.SetActive(!b.activeSelf));
    }
}
