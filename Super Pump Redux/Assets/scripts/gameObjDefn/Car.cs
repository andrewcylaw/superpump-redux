using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speed = rb.velocity;
    }
    
    public void StopCar() {
        rb.velocity = Vector2.zero;
    }

    public void StartCar() {
        rb.velocity = speed;
    }

}
