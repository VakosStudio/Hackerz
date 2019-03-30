using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public Camera cam;
    public float dmg = 1f;

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
            DamageTree tree = hit.transform.GetComponent<DamageTree>();
            if ((hit.transform.tag == "Tree") && (tree != null))
            {
                Debug.Log("Trafiles!");
                tree.Damage(dmg);
            }
        }
    }
}
