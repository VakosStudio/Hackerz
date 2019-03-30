using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public Camera cam;
    public Animator anim;
    public float dmg = 1f;
    public float FireRate = 15f;
    private float nextTimeToFire = 0f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && (Time.time >= nextTimeToFire))
        {
            nextTimeToFire = Time.time + 1f / FireRate;
            Hit();
        }
    }

    public void Hit()
    {
        RaycastHit hit;

        StartCoroutine(Siekiera());

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 30f))
        {

            DamageTree tree = hit.transform.GetComponent<DamageTree>();
            if ((hit.transform.tag == "Tree") && (tree != null))
            {
                Debug.Log("Trafiles!");
                tree.Damage(dmg);
            }
        }
    }

    IEnumerator Siekiera ()
    {
        anim.SetBool("isHiting", true);
        yield return new WaitForSeconds(.3f);
        anim.SetBool("isHiting", false);
    }
}
