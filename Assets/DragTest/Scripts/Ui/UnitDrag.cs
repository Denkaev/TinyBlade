using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class UnitDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private UnitData _unitData;

    private UnitDrag _spawnedUnitUi;
    private bool _canMove;
    private Transform _mainCanvas;
    private CanvasGroup _canvasGroup;

    public void Init(UnitData unitData)
    {
        _unitData = unitData;
        GetComponent<Image>().sprite = _unitData.sprite;
        _mainCanvas = transform.root;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        int siblingIndex = transform.GetSiblingIndex();

        if (_spawnedUnitUi == null)
        {
            _spawnedUnitUi = Instantiate(_unitData.uiPrefab, transform.parent).GetComponent<UnitDrag>();
            _spawnedUnitUi.Init(_unitData);
            _spawnedUnitUi.transform.SetSiblingIndex(siblingIndex);
        }

        transform.SetParent(_mainCanvas);
        transform.position = eventData.position;
        _canMove = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!_canMove)
            return;

        transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _canMove = false;

        Collider2D dropped = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (dropped == null)
        {
            Destroy(gameObject);
            return;
        }

        SpriteRenderer unit = Instantiate(_unitData.gamePrefab, dropped.transform.position, Quaternion.identity).GetComponent<SpriteRenderer>();
        unit.color = _unitData.color;

        Destroy(gameObject);
    }
}
