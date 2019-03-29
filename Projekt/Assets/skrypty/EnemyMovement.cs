using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerHealth player;
    private GameObject Target;
    public float Speed;
    public float rotSpeed;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("gracz");
        player = GameObject.FindGameObjectWithTag("PM").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), rotSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "gracz")
        {
            player.Death(true);
        }
    }
}
