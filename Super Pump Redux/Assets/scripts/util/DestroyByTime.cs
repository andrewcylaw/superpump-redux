using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float spawnToDeathTime;

    void Awake()
    {
        Destroy(gameObject, spawnToDeathTime);
    }

}
