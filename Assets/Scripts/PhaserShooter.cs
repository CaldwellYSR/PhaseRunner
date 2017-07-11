using UnityEngine;

public class PhaserShooter : MonoBehaviour
{

    public Transform PhaserLaunchPosition;
    public GameObject PhaserPrefab;
    public float LaunchForce;

    private bool hasPhaser = true;
    private GameObject Phaser;
	
	void Update ()
    {

        if (Input.GetButtonDown("Fire") && hasPhaser)
        {
            Fire();
        }

        if (Input.GetButtonDown("Teleport") && !hasPhaser)
        {
            Teleport();
        }
        else if (Input.GetButtonDown("Cancel") && !hasPhaser)
        {
            ResetPhaser();
        }
		
	}

    private void Fire()
    {
        hasPhaser = false;
        Phaser = GameObject.Instantiate(PhaserPrefab, PhaserLaunchPosition.position, new Quaternion(0f, 0f, 0f, 0f));
        Rigidbody PhaserRigidbody = Phaser.GetComponent<Rigidbody>();
        PhaserRigidbody.AddForce(PhaserLaunchPosition.forward * LaunchForce);
    }

    private void Teleport()
    {
        hasPhaser = true;
        transform.position = Phaser.transform.position;
        Destroy(Phaser);

    }

    private void ResetPhaser()
    {
        hasPhaser = true;
        Destroy(Phaser);

    }

}
