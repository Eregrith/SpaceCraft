using UnityEngine;

public class AsteroidController : MonoBehaviour {

    private float RotationSpeed { get; set; }
    private int SpriteIndex { get; set; }
    public Sprite[] Sprites;
    public GameObject PickupSpawned;
    public int MinimumSpawn;
    public int MaximumSpawn;

    void Start () {
        RotationSpeed = Random.Range(-3f, 3f);
        transform.Rotate(0, 0, 500*RotationSpeed);
        GetComponent<SpriteRenderer>().sprite = Sprites[Random.Range(0, Sprites.Length)];
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, RotationSpeed);
	}

    private void OnDestroy()
    {
        SpawnResources();
    }

    private void SpawnResources()
    {
        Debug.Log("Spawning resources !");
        int spawned = Random.Range(MinimumSpawn, MaximumSpawn);
        Debug.Log("Spawning " + spawned);
        while (spawned > 0)
        {
            Instantiate(PickupSpawned, this.transform.position, new Quaternion());
            spawned--;
        }
    }
}
