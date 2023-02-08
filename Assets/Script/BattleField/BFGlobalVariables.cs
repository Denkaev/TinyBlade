using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BFGlobalVariables : MonoBehaviour
{
    static public List<GameObject> MoveTurn = new List<GameObject>();
    static public int ListIndex = -1;
    //static private GameObject[] UnitProperties;
    static public int AddNew(GameObject gameObject)
    {
        MoveTurn.Add(gameObject);
        return ListIndex += 1;
    }
    static public int Next()
    {
        if (MoveTurn.Count - 1 == ListIndex)
            ListIndex = 0;
        else
            ListIndex += 1;

        //UnitProperties = GameObject.FindGameObjectsWithTag("UnitProperties");
        ////надо перебрать объекты и поменять им всем цвет(пока одному)
        //foreach (var item in UnitProperties)
        //{
        //    //Debug.Log(item.tag);
        //     //var text = item.GetComponent("Text");
        //    //MoveTurn[ListIndex]
        //    //gameObject
        //    //text.font.material.color 
        //    //"RGBA(1.000, 1.000, 1.000, 1.000)"
        //    //         Debug.Log(text.text); 
        //}
        return ListIndex;
    }
    static public GameObject GetCurrent()
    {
        return MoveTurn[ListIndex];
    }

}
