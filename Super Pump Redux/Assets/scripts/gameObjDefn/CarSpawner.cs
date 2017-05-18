using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spawns cars that travel towards the left.
 * 
 */
public class CarSpawner : MonoBehaviour {

    public GameObject[] cars;

    // Randomly picks a car from the available car and spawns it according to speed with tag.
	public GameObject SpawnCar(string tag, float speed) {        
        GameObject spawnedCar = Instantiate(cars[(int)Random.Range(0, cars.Length)], transform.localPosition, transform.localRotation);
        spawnedCar.tag = tag;
        spawnedCar.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);

        return spawnedCar;
    }
}
