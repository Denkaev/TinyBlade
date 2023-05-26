using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TinyMenu : MonoBehaviour
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

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
