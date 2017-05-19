using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class Car : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 speed;
    private Stopwatch fuelStopwatch;

    private CarMoneyBubbleManager cmbm;

    void Start() {
        cmbm = GetComponent<CarMoneyBubbleManager>();

        fuelStopwatch = new Stopwatch();
        rb = GetComponent<Rigidbody2D>();
        speed = rb.velocity;
    }

    void Update() {
        cmbm.ShowFuelAmount(fuelStopwatch);
    }
    
    public void StopCar() {
        rb.velocity = Vector2.zero;
    }

    public void StartCar() {
        rb.velocity = speed;
    }

    // Car manages its own fuel
    public void StartStopwatch() {
        fuelStopwatch.Start();
    }

    public void StopStopwatch() {
        fuelStopwatch.Stop();
    }

    public void FlashText() {
        cmbm.HideUI();
    }

}
