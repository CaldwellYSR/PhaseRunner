using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;
    public float gravity = 20f;
    public float jumpSpeed = 7f;

    private float HorizontalMovement, VerticalMovement;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(HorizontalMovement, 0, VerticalMovement);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
	}

    void FixedUpdate()
    {
        controller.Move(moveDirection * Time.deltaTime);
    }
}
