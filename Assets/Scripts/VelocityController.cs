using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour {

    public float initialVelocity = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
