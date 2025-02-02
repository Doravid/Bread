using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemMovement : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Transform parent;
    private Canvas canvas;
   private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parent = transform.parent;
        canvasGroup = GetComponent<CanvasGroup>();
        if (GameObject.Find("PlayerUI") != null) canvas = GameObject.Find("PlayerUI").GetComponent<Canvas>();
        else Debug.LogError("Couldn't Find PlayerUI");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        gameObject.transform.SetParent(canvas.transform, false);
        rectTransform.position= Input.mousePosition;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent, false);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }
}
