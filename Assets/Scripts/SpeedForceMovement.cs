using UnityEngine;

public class SpeedForceMovement : MonoBehaviour {

    public float Distance;
    public float Speed;

	void FixedUpdate () {

        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + Distance * Mathf.Sin(Speed * Time.time), pos.z);

	}
}
