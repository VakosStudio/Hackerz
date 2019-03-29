using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Canvas inventory;

    void Start()
    {
        inventory = (Canvas)GetComponent<Canvas>();
        inventory.enabled = false;
    }

    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.I))
        {
            inventory.enabled = !inventory.enabled;
            Cursor.visible = !inventory.enabled;

            if(inventory.enabled)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }
}
