using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfWood : MonoBehaviour
{
    private Text wood;
    public int number = 1;

    public void Start()
    {
        wood = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        wood.text = number.ToString();
    }
}
