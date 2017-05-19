using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this an object you want to last
public class NoDestroy : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
