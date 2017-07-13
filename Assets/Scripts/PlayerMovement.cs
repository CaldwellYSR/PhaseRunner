using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;
    public float gravity = 20f;
    public float jumpSpeed = 7f;

    private float HorizontalMovement, VerticalMovement;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private bool canDoubleJump = false;
    private Vector3 wallCollisionPoint;

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
            if (Input.GetButtonDown("Jump"))
            {
                canDoubleJump = true;
                Jump();
            }
        }
        else
        {
            if (controller.collisionFlags == CollisionFlags.Sides)
            {
                canDoubleJump = false;
                if (Input.GetButtonDown("Jump"))
                {
                    canDoubleJump = true;
                    WallJump();
                }
            }
            else if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                canDoubleJump = false;
                Jump();
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
	}

    void FixedUpdate()
    {
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Jump()
    {
        moveDirection.y = jumpSpeed;
    }

    private void WallJump()
    {
        moveDirection += wallCollisionPoint * 2;
        Jump();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            wallCollisionPoint = hit.collider.ClosestPointOnBounds(transform.position) - transform.position;
        }
    }
}
