using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public GameObject PickupSpawned;
    public int MinimumSpawn;
    public int MaximumSpawn;

    void Start () {
    }
	
	void Update ()
    {
        //transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime, Space.Self);
	}

    private void OnDestroy()
    {
        //SpawnResources();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Debug.Log("Sticking !" + Time.time);
            FixedJoint2D joint = this.gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            joint.anchor = transform.InverseTransformPoint(collision.contacts[0].point);
            joint.connectedAnchor = collision.gameObject.transform.InverseTransformPoint(collision.contacts[0].point);
        }
    }

    private void SpawnResources()
    {
        int spawned = Random.Range(MinimumSpawn, MaximumSpawn);
        while (spawned > 0)
        {
            Instantiate(PickupSpawned, this.transform.position, new Quaternion());
            spawned--;
        }
    }
}
