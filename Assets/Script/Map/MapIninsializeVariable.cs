using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIninsializeVariable : MonoBehaviour
{
    void Awake()
    {
        MapGlobalVariables.FreeCam = true;
    }

}
