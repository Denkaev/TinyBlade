using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownMenuRightSide : MonoBehaviour
{
    [SerializeField]
    private GameObject farm;

    public void PressButon()
    {
        //Пока включить выключить
        //Потом анимация постройки , постройка , убрать кнопку из листа возможных построек
        Invert(farm);
    }


    public void Invert(GameObject build)
    {
        build.SetActive(!build.activeSelf);
    }
}
