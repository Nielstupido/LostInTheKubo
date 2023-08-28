using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 velocity;
    private float gravity = -25f;
    private float speed = 20f;
    private float jumpForce = 15f;
    private Vector3 moveDirection;

    void Update()
    {
        moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")));
        moveDirection *= speed;

        if (gameObject.GetComponent<CharacterController>().isGrounded)
        {
            velocity.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y += gravity * 2f * Time.deltaTime;
        }

        gameObject.GetComponent<CharacterController>().Move(moveDirection * Time.deltaTime);
        gameObject.GetComponent<CharacterController>().Move(velocity * Time.deltaTime);
    }
}
