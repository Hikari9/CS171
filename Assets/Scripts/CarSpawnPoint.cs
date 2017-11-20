using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnPoint : MonoBehaviour {

    public GameObject carPrefab;
    public float averageSpawnTime = 4.0f;
    public float minimumSpawnTime = 2.0f;

    [Range(0f, 100f)]
    public float carMinInitialSpeedMPH = 20f;

    [Range(0f, 100f)]
    public float carMaxInitialSpeedMPH = 20f;

    // keep track of previous spawn time
    protected float nextSpawnTime;

    // Use this for initialization
    void Start () {
        AssignNextSpawnTime();
    }

    // assign the next spawn tie based on exponential distribution
    void AssignNextSpawnTime() {
        nextSpawnTime = Time.time + ProbabilityExponential(averageSpawnTime - minimumSpawnTime) + minimumSpawnTime;
    }

    // exponential distribution probablity solver
    float ProbabilityExponential(float mean) {
        return -Mathf.Log(1.0f - Random.value) * mean;
    }

    private GameObject previousCar;

    // setup the instantiated car
    void SetupCar(GameObject car) {
        float speed = Random.Range(carMinInitialSpeedMPH, carMaxInitialSpeedMPH);
        car.GetComponent<Rigidbody>().velocity = car.transform.forward * speed;
        previousCar = car;
    }

    // get spawn position of car, offset if would collide with previously instantiated car
    Vector3 InstantiationPosition() {
        if (previousCar != null &&
            Vector3.Dot(previousCar.transform.position - transform.position, transform.forward) < 10f) {
            return previousCar.transform.position - transform.forward * 20f;
        } else {
            return transform.position;
        }
    }

	// Update is called once per frame
	void Update () {
        if (Time.time >= nextSpawnTime) {
            // spawn a new car at this point, in the same orientation
            SetupCar(Instantiate(carPrefab, InstantiationPosition(), transform.rotation));
            
            // get next time to spawn
            AssignNextSpawnTime();
        }
	}
}
