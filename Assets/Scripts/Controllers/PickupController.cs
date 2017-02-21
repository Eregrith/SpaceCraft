using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    private bool IsActive;
    public float SecondsInert;
    public float SpreadTime;
    private float RemainingSpreadTime;
    private bool IsSpreading;
    private Vector3 Direction;

    // Use this for initialization
    void Start () {
        IsSpreading = true;
        Direction = new Vector3(1, 0);
        Direction = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * Direction;
        RemainingSpreadTime = SpreadTime;
    }
	
	// Update is called once per frame
	void Update () {
		if (!IsActive)
        {
            SecondsInert -= Time.deltaTime;
            if (SecondsInert <= 0) IsActive = true;
        }
        if (IsSpreading)
        {
            this.transform.Translate(Direction * Time.deltaTime * (RemainingSpreadTime / SpreadTime));
            RemainingSpreadTime -= Time.deltaTime;
            if (RemainingSpreadTime <= 0) IsSpreading = false;
        }
	}
}
