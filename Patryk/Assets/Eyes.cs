using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public Camera cam;
    public DamageTree tree;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Hit();
        }
    }

    public void Hit()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5f))
        {
            if(hit.transform.tag == "Tree")
            {
                tree.Damage();
                Debug.Log("Trafiles!");
            }
        }
    }
}
