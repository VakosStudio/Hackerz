using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Canvas inventory;
    public PlayerLook look;
    public PlayerMove move;
    public Eyes eye;

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
                eye.enabled = false;
                look.enabled = false;
                move.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                eye.enabled = true;
                look.enabled = true;
                move.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }
}
