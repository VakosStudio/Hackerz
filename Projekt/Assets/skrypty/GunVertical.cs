using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunVertical : MonoBehaviour
{
    float UpDown;
    public GameObject gun0;
    public GameObject gun1;
    public GameObject gun2;
    public float speed;
    public CharacterController characterControler;

    void Start()
    {
        characterControler = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpDown += Input.GetAxis("Mouse Y") * speed;
        UpDown = Mathf.Clamp(UpDown, -20f, 30f);
        gun0.transform.localRotation = Quaternion.Euler(-UpDown, 0, 0);
        gun1.transform.localRotation = Quaternion.Euler(-UpDown, 0, 0);
        gun2.transform.localRotation = Quaternion.Euler(-UpDown, 0, 0);
    }
}
