using UnityEngine;

public class CollectSpeedForce : MonoBehaviour {

    public string Tag;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == Tag)
        {
            Score(other.transform.parent.gameObject);
        }
    }

    private void Score(GameObject other)
    {
        Destroy(other);
    }

}
