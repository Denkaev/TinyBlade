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
        Vector3 mousePosition = Input.mousePosition;
        //mousePosition.y = Camera.main.transform.position.y;
        mousePosition.y = -2f;
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //GPT �� ����� � Unity
        Vector3 worldPosition = Camera.main.ScreenToViewportPoint(mousePosition);

        prefabCurrent = Instantiate(unitPrefab, worldPosition, Quaternion.identity);
        
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
        Debug.Log("OnPointerDown");//������ ������� �� ������������� ������� �������
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
