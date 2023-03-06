using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 startPosition;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        RectTransform fieldRectTransform = /* получить RectTransform поля */;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(fieldRectTransform, eventData.position, null, out localPoint);

        if (RectTransformUtility.RectangleContainsScreenPoint(fieldRectTransform, eventData.position))
        {
            //rectTransform.SetParent(/* установить родительский объект на поле */);
            rectTransform.anchoredPosition = localPoint;
        }
        else
        {
            rectTransform.anchoredPosition = startPosition;
        }
    }
}
