using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float rotationSpeed = 2.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        SetPlayerToGround();
        Movement();
        Jump();
        
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void SetPlayerToGround()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);

        playerVelocity.y += gravityValue * Time.deltaTime;
    }

    private void Movement()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move.Normalize();
        
        controller.Move(move * (Time.deltaTime * playerSpeed));

        if (move == Vector3.zero)
            return;
        
        var toRotation = Quaternion.LookRotation(move, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}