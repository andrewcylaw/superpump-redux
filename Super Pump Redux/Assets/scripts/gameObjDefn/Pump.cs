using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/*
 * Responsible for the following:
 *     - Telling the attached car to leave when it is parked
 *     - Starting the timer
 *     - 
 * 
 */
public class Pump : MonoBehaviour {

    private float MIN_SPEED = -5.0f;
    private float MAX_SPEED = -10.0f;

    public string pumpTag;
    public CarSpawner carSpawner;
    private Stopwatch fuelStopwatch;
    private GameObject currentCar; // Any car that is fueling or moving towards/away from pump

    void Start() {
        tag = pumpTag;

        // for testing purposes
        SpawnCar();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag(tag)) {
            collider.gameObject.GetComponent<Car>().StopCar();
            UnityEngine.Debug.Log("matching cars on tag: " + tag.ToString());
        }
    }

    public void SpawnCar() {        
        currentCar = carSpawner.SpawnCar(tag, (float) Random.Range(MIN_SPEED, MAX_SPEED));
    }

}
