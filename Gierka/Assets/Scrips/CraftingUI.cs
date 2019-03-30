using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    public GameObject craftui;
    public PlayerLook look;
    public PlayerMove move;
    public Eyes eye;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            craftui.SetActive(true);
            look.enabled = false;
            move.enabled = false;
            eye.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            craftui.SetActive(false);
            look.enabled = true;
            move.enabled = true;
            eye.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
