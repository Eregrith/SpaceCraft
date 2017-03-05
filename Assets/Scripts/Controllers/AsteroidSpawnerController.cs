using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AsteroidSpawnerController : MonoBehaviour {

    public AsteroidSpawnable[] Asteroids;
    public float SpawnInterval;
    private float SpawnTimer;

    private GameObject SpawnAsteroid(AsteroidSpawnable spawnable)
    {
        GameObject asteroid = Instantiate(spawnable.Asteroid, new Vector3(), Quaternion.identity);

        float rotationSpeed = UnityEngine.Random.Range(-90f, 90f);
        asteroid.transform.Rotate(0, 0, 500 * rotationSpeed);
        float force = (15 + UnityEngine.Random.Range(0, 15));
        float angle = UnityEngine.Random.Range(0, 360);
        Vector2 movement = Quaternion.AngleAxis(angle, Vector3.forward) * new Vector2(force, 0);
        asteroid.GetComponent<Rigidbody2D>().AddForce(movement);

        return asteroid;
    }

    private void TrySpawningAsteroids()
    {
        List<GameObject> spawned = new List<GameObject>();
        foreach (AsteroidSpawnable spawnable in Asteroids)
            if (UnityEngine.Random.value <= spawnable.SpawnChance)
                spawned.Add(SpawnAsteroid(spawnable));

        if (spawned.Count > 1)
            SpaceAsteroidsAround(spawned.First(), spawned.Skip(1));
    }

    private void SpaceAsteroidsAround(GameObject center, IEnumerable<GameObject> spawned)
    {
        float width = center.GetComponent<PolygonCollider2D>().bounds.extents.x * 2;

        foreach (GameObject asteroid in spawned)
        {
            asteroid.transform.Rotate(Vector3.forward, UnityEngine.Random.Range(0, 360));
            asteroid.transform.Translate(width, 0, 0);
        }
    }

    public void Start()
    {
        SpawnTimer = SpawnInterval;
    }

    public void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0)
        {
            SpawnTimer = SpawnInterval;
            TrySpawningAsteroids();
        }
    }
}
