using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject[] clouds;
    public float ySpawnOffsetLowerBound;
    public float ySpawnOffsetUpperBound;
    public float velLowerBound;
    public float velUpperBound;
    public float waitLowerBound;
    public float waitUpperBound;

    public float cloudLifeSeconds;
    public int sizeRange;

	void Start () {
        StartCoroutine(SpawnClouds());
    }

    /**
     * A coroutine that periodocially spawns clouds with a randomly ranged y spawn offset, velocity, and wait between cloud spawns.
     */
    IEnumerator SpawnClouds()
    {
        Vector2 spawnSpot;
        GameObject spawnedCloud;
        Vector2 spawnParent;
        int randVal;

        while (true)
        {            
            spawnParent = GetComponent<RectTransform>().anchoredPosition;           
            spawnSpot = new Vector2(spawnParent.x, spawnParent.y + Random.Range(ySpawnOffsetLowerBound, ySpawnOffsetUpperBound));
            randVal = Random.Range(0, clouds.Length);
           
            spawnedCloud = Instantiate(clouds[randVal], spawnSpot, gameObject.GetComponent<Transform>().rotation) as GameObject;
            spawnedCloud.transform.SetParent(gameObject.transform, false);

            // Randomly scale size of cloud
            randVal = Random.Range(0, sizeRange);
            spawnedCloud.transform.localScale -= new Vector3(randVal, randVal);            

            // Move cloud 
            Rigidbody2D rb = spawnedCloud.GetComponent<Rigidbody2D>();            
            rb.velocity = new Vector2(Random.Range(velLowerBound, velUpperBound), 0.0f);

            yield return new WaitForSeconds(Random.Range(waitLowerBound, waitUpperBound));
        }
    }


}
