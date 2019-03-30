using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{

    public Vector3 delta;
    Vector3 startPosition;
    public GameObject Fance;
    public GameObject Cube;
    collectingmaterials col;


    void Start()
    {
        startPosition = gameObject.transform.position;
    }


    void Update()
    {

        Physics.Raycast(transform.position, Vector3.forward, 3f);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (0 == 0)
            {
                Instantiate(Fance, Cube.transform.position, Quaternion.identity);
                col.woods -= 0;
            }
            else
            {
                Debug.Log("Nie zbudujesz");
            }
        }

    }
}