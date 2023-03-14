using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BFUnitDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject unitPrefab;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject prefabCurrent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //prefabCurrent = Instantiate(unitPrefab,rectTransform);
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //потом разберусь с этим костылем
        //Transform unitPos;
        
        //var unitPos = mousePosition;
        //unitPos.x = mousePosition.x;
        //unitPos.y = mousePosition.y;
        //unitPos.z = mousePosition.y;
        //mousePosition.z = 0;
        //prefabCurrent = Instantiate(unitPrefab, (Transform)Input.mousePosition);
        //prefabCurrent = Instantiate(unitPrefab, mousePosition, Quaternion.identity);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray))
        prefabCurrent = Instantiate(unitPrefab);
        //prefabCurrent = Instantiate(unitPrefab, mousePosition);

        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        //Destroy(prefabCurrent);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");//Размер объекта не соответствует размеру страйта
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
