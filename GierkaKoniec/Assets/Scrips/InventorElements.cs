using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorElements : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform window;
    private Transform Trans;

    public ItemsType type = ItemsType.weapon;

    

    void Start()
    {
        Trans = GetComponent<Transform>();
        window = Trans.parent;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnbeginDrag");
        Trans.SetParent(window.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Trans.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        Trans.SetParent(window);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }

    public Transform getWindow()
    {
        return window;
    }

    public void setWindows(Transform Trans)
    {
        window = Trans;
    }
}
