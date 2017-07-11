using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;

    private float HorizontalMovement, VerticalMovement;
    private Rigidbody m_Rigidbody;

	void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
	}

    void FixedUpdate()
    {
        Vector3 movement = ((transform.forward * VerticalMovement) + (transform.right * HorizontalMovement)) * Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
}
