using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    public float Speed;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 translation = new Vector3(Speed, 0, 0);
        translation = Quaternion.Euler(0, 0, transform.rotation.z) * translation;

        transform.Translate(translation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision !");
        Debug.Log("Collider :");
        Debug.Log(collision.collider);
        if (collision.collider.tag == "Asteroid")
        {
            Destroy(collision.collider);
            Destroy(this);
        }
    }
}
