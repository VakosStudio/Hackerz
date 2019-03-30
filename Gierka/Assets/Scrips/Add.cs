using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{
    public GameObject Fance;
    public GameObject Cube;
    public GameObject Player;
    public NumberOfWood wood;

    void Update()
    {

        Physics.Raycast(transform.position, Vector3.zero, 3f);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (wood.number >= 4)
            {
                Instantiate(Fance, Cube.transform.position, Player.transform.rotation);
                wood.number -= 4;
            }
            else
            {
                Debug.Log("Nie zbudujesz");
            }
        }

    }
}