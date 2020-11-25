using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovementController : NetworkBehaviour
{

    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private CharacterController controller = null;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask groundMask;

    private float groundDistance = 0.4f;
    private bool isGrounded;
    private Vector2 previousInput;
    private Controls controls;
    private float movementSpeed;
    private Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }

    public override void OnStartAuthority()
    {
        enabled = true;
        movementSpeed = baseSpeed;
        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => ResetMovement();
    }

    [ClientCallback]

    private void OnEnable() => Controls.Enable();
    [ClientCallback]
    private void OnDisable() => Controls.Disable();
    [ClientCallback]
    private void Update() => Move();

    [Client]
    private void SetMovement(Vector2 movement) => previousInput = movement;
    [Client]
    private void ResetMovement() => previousInput = Vector2.zero;
    [Client]
    private void Move()
    {
        Vector3 right = controller.transform.right;
        Vector3 forward = controller.transform.forward;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        
        
        right.y = 0f;
        forward.y = 0f;

        Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y;

        if (isGrounded && movement.y < 0)
        {
            movement.y = -2f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
            movementSpeed = baseSpeed * 1.5f;
        else { movementSpeed = baseSpeed; }

        movement.y += gravity;
        controller.Move(movement * movementSpeed * Time.deltaTime);
    }



}
