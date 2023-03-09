using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class DraggableSpriteRenderer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public SpriteRenderer _SpriteRenderer => this._spriteRenderer;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        Vector3 movement = new Vector3(
            x: eventData.delta.x * Time.deltaTime,
            y: eventData.delta.y * Time.deltaTime
        );

        this.transform.localPosition += movement;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

#if UNITY_EDITOR
    private void Reset()
    {
        this._spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
#endif
}