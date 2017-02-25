using UnityEngine;

public class AsteroidController : MonoBehaviour {

    private float RotationSpeed { get; set; }
    private Vector3 Movement { get; set; }
    public Sprite[] Sprites;
    public GameObject PickupSpawned;
    public int MinimumSpawn;
    public int MaximumSpawn;

    void Start () {
        RotationSpeed = Random.Range(-90f, 90f);
        transform.Rotate(0, 0, 500*RotationSpeed);
        GetComponent<SpriteRenderer>().sprite = Sprites[Random.Range(0, Sprites.Length)];
        Movement = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }
	
	void Update ()
    {
        transform.Translate(Movement.x * Time.deltaTime, Movement.y * Time.deltaTime, 0, Space.World);
        transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime, Space.Self);
	}

    private void OnDestroy()
    {
        //SpawnResources();
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
