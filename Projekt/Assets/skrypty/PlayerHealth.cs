using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float resTime = 3f;
    private Movement ruch;
    private Transform gracz;
    private Transform respawn;
    private Animator anim;
    public GameObject player;
    public GameObject respawnUI;

    public void Start()
    {
        ruch = GameObject.FindGameObjectWithTag("gracz").GetComponent<Movement>();
        gracz = GameObject.FindGameObjectWithTag("gracz").GetComponent<Transform>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        anim = GameObject.FindGameObjectWithTag("gracz").GetComponent<Animator>();
    }

    public void Death(bool touch)
    {
        if(touch == true)
        {
            Debug.Log("Trafiony!");
            StartCoroutine(Die());
            player.SetActive(false);
        }
    }

    IEnumerator Die()
    {
        respawnUI.SetActive(true);
        ruch.enabled = false;
        player.tag = "Untagged";
        yield return new WaitForSeconds(resTime);
        gracz.transform.position = respawn.transform.position;
        respawnUI.SetActive(false);
        player.SetActive(true);
        ruch.enabled = true;
        anim.SetFloat("respawn", 1f);
        yield return new WaitForSeconds(3f);
        anim.SetFloat("respawn", 0f);
        player.tag = "gracz";
    }
}
