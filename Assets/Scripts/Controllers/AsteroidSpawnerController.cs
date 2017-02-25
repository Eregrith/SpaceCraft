using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerController : MonoBehaviour {

    public AsteroidSpawnable[] Asteroids;
    public float SpawnInterval;
    private float SpawnTimer;

    private void SpawnAsteroid(AsteroidSpawnable spawnable)
    {
        Instantiate(spawnable.Asteroid, new Vector3(), Quaternion.identity);
    }

    private void TrySpawningAsteroids()
    {
        foreach (AsteroidSpawnable spawnable in Asteroids)
            if (Random.value <= spawnable.SpawnChance)
                SpawnAsteroid(spawnable);
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
