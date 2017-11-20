using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawn : MonoBehaviour {

    public Vector3 SpawnPoint;
    public double TravelDistance;
	
	// Update is called once per frame
	void Update () {
        if ((this.transform.position - this.SpawnPoint).magnitude >= this.TravelDistance) {
            GameObject.Destroy(this);
        }
	}
}
