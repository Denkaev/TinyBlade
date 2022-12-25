using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu
{
    public void Building()
    {
        Debug.Log("Building");
    }

    public void Quit()
    {
        //Need check for editor
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void Mercenaries()
    {
        Debug.Log("Mercenaries");
    }

}
