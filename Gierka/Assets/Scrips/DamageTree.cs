using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTree : MonoBehaviour
{
    public float Health = 5f;
    public GameObject destroyTree;
    public collectingmaterials col;

    public void Damage(float dmg)
    {
        Health -= dmg;

        if(Health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        GameObject.Instantiate(destroyTree, destroyTree.transform.position + transform.position, transform.rotation);
        col.collectingwoods();
    }
}
