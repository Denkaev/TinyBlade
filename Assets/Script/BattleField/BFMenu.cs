using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFMenu : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void Next()
    {
        BFGlobalVariables.Next();
        // не работает
        //     GlobalVariables.MoveTurn[GlobalVariables.ListIndex].GetComponent<Move>().SetStepsRemain();
    }

}
