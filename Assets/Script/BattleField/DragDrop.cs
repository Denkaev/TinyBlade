using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler 
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Take Item");//Размер объекта не соответствует размеру страйта
    }
}
