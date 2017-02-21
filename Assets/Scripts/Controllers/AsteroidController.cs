using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    private float RotationSpeed { get; set; }
    private int SpriteIndex { get; set; }
    public Sprite[] Sprites;
    
    void Start () {
        RotationSpeed = Random.Range(-3f, 3f);
        transform.Rotate(0, 0, 500*RotationSpeed);
        GetComponent<SpriteRenderer>().sprite = Sprites[Random.Range(0, Sprites.Length)];
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, RotationSpeed);
	}
}
