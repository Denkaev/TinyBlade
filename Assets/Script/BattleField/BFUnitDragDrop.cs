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
    //Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition);
    //new version
    Ray MyRay;
    RaycastHit hit;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Vector3 mousePosition = Input.mousePosition;
        ////mousePosition.y = Camera.main.transform.position.y;
        //mousePosition.y = -2f;
        ////Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        ////GPT не шарит в Unity
        //Vector3 worldPosition = Camera.main.ScreenToViewportPoint(mousePosition);

        //prefabCurrent = Instantiate(unitPrefab, worldPosition, Quaternion.identity);

        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        //new version
        //MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(MyRay.origin, MyRay.direction * 10, Color.yellow);
        //if (Physics.Raycast(MyRay, out hit, 100))
        //{
        //    MeshFilter filter = hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;
        //    if (filter)
        //    {
        //        //имя обьекта по которому щелкнули мышей               
        //        Debug.Log(filter.gameObject.name);

        //    }
        //}

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
        
        //new version
        MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(MyRay.origin, MyRay.direction * 10, Color.yellow);
        if (Physics.Raycast(MyRay, out hit, 100))
        {
            MeshFilter filter = hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;
            if (filter)
            {
                //имя обьекта по которому щелкнули мышей               
                Debug.Log(filter.gameObject.name);
                Instantiate(unitPrefab, filter.transform.position, Quaternion.identity);

            }
        }
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
