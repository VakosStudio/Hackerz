using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController character;
    public float moveSpeed;
    private Vector3 moveDirector;
    public float gravityScale;

    public void Start()
    {
        character = GetComponent<CharacterController>();
    }

    public void Update()
    {
        moveDirector = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirector = moveDirector.normalized * moveSpeed;

        moveDirector.y = moveDirector.y + (Physics.gravity.y * gravityScale);
        character.Move(moveDirector * Time.deltaTime);
    }
}
