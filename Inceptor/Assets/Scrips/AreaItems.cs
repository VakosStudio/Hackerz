using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AreaItems : MonoBehaviour, IDropHandler
{
    public ItemsType type = ItemsType.weapon;
    public GameObject ObjectInventory;

    public int maxItems;

    private Transform trans;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "upuszczono w" + gameObject.name);

        InventorElements d = eventData.pointerDrag.GetComponent<InventorElements>();
        if (d != null)
        {
            if (type == d.type)
            {
                Debug.Log(trans.childCount);
                if (trans.childCount < maxItems)
                {
                    d.setWindows(trans);
                }
                else
                {
                    Transform elem = transform.GetChild(0);
                    elem.SetParent(ObjectInventory.transform);
                    d.setWindows(trans);
                }
            }
            else if (type == ItemsType.weapon)
            {
                d.setWindows(trans);
            }
        }
    }
}
