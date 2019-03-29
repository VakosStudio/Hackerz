using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float StartHealth = 2f;
    private float Health;
    public Image HealthBar;

    public void Start()
    {
        Health = StartHealth;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        HealthBar.fillAmount = Health / StartHealth;
        if(Health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
