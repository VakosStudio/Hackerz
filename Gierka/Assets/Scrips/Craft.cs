using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Craft : MonoBehaviour
{
    public Button craft;
    public NumberOfWood wood;

    public void OnEnable()
    {
        craft.onClick.AddListener(delegate { Crafting(); });
    }

    public void Crafting()
    {
        if(wood.number >= 4)
        {
            wood.number -= 4;

        }
    }
}
