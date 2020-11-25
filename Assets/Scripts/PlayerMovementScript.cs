using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovementScript : NetworkBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeigh = 1f;
    public Transform groundCheck;

    
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;
    private float baseSpeed;

    Vector3 velocity;

    private void Start()
    {
        baseSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
       // if (isLocalPlayer)
       // {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeigh * -2f * gravity);
            }

            if (Input.GetKey(KeyCode.LeftShift))
                speed = baseSpeed * 1.5f;
            else { speed = baseSpeed; }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
      //  }
    }
}
