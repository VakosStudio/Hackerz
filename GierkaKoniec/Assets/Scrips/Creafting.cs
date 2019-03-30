using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creafting : MonoBehaviour
{
    collectingmaterials col;
    public GameObject axe;
    public Button button; 

    public void OnMouseDown()
    {
        creafting();
    }

    /*public void OnEnable()
    {
        button.onClick.AddListener(delegate { creafting(); });
    }*/

    public void creafting()
    {
        Debug.Log("eeeee");
        if (gameObject.tag == "Axe")
        {
            if (col.woods >= 1 && col.sticks >=3)
            {
                Instantiate(axe, transform.position, Quaternion.identity);
            }
        }

    }
}
