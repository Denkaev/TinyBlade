using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IninsializeVariable : MonoBehaviour
{
    void Awake()
    {
        GlobalVariables.FreeCam = true;
    }

}
