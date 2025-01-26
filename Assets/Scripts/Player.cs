using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 playerVelocity;
    public float playerSpeed = 6.0f;
    public float rotationSpeed = 700f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Movement();
        
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Movement()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        move.Normalize();
        
        controller.Move(move * (Time.deltaTime * playerSpeed));

        if (move == Vector3.zero)
            return;
        
        var toRotation = Quaternion.LookRotation(move, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}