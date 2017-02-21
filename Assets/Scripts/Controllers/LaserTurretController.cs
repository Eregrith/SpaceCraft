using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurretController : MonoBehaviour {

    public GameObject Cannon;
    public GameObject Laser;
    public float ShotCooldown;
    public Transform LaserSpawner;
    private float nextShoot;

	// Use this for initialization
	void Start () {
        nextShoot = 0;
	}

    // Update is called once per frame
    void Update()
    {
        RotateTurret();
        HandleShoot();
    }

    private void RotateTurret()
    {
        Vector3 mouse = Input.mousePosition;

        var pos = Camera.main.WorldToScreenPoint(Cannon.transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -45, 45);

        Cannon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void HandleShoot()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > nextShoot)
        {
            nextShoot = Time.time + ShotCooldown;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(Laser, LaserSpawner.position, Cannon.transform.rotation);
    }
}
