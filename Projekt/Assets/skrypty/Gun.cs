using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 1f;
    public float FireRate = 15f;
    private float nextTimeToFire = 0f;

    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1f;
    public float impactForce = 30f;
    public float range = 100f;
    private bool isReloading = false;
    public Animator animator;
    private Text bulets;
    public ParticleSystem shoot;
    public GameObject dust;

    public Camera cam;

    public void Start()
    {
        bulets = GameObject.FindGameObjectWithTag("Bulets").GetComponentInChildren<Text>();
        currentAmmo = maxAmmo;
    }

    public void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    public void Update()
    {
        bulets.text = currentAmmo + "/" + maxAmmo;

        if (isReloading == true)
        {
            return;
        }

        if ((currentAmmo <= 0) || Input.GetKey(KeyCode.R) && (currentAmmo != maxAmmo))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / FireRate;
            Shot();
        }
    }

    IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        isReloading = true;
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        isReloading = false;
        currentAmmo = maxAmmo;
    }

    public void Shot()
    {
        shoot.Play();
        currentAmmo--;
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward,out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target!=null)
            {
                target.TakeDamage(damage);
            }
        }

        if(hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }

        GameObject impactGO = Instantiate(dust, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 1.5f);
    }
}
