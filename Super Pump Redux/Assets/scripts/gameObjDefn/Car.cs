using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class Car : MonoBehaviour {
    // Forgive me for hard coding everything...
    private static int MONEY_LOWER = 4;
    private static int MONEY_UPPER = 12;

    private Rigidbody2D rb;
    private Vector2 speed;
    private Stopwatch fuelStopwatch;
    private int money;

    private CarMoneyBubbleManager cmbm;

    void Start() {
        cmbm = GetComponent<CarMoneyBubbleManager>();

        fuelStopwatch = new Stopwatch();
        rb = GetComponent<Rigidbody2D>();
        speed = rb.velocity;

        money = Random.Range(MONEY_LOWER, MONEY_UPPER);       
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
    public Stopwatch GetStopwatch() {
        return fuelStopwatch;
    }

    public void StartStopwatch() {
        fuelStopwatch.Start();
    }

    public void StopStopwatch() {
        fuelStopwatch.Stop();
    }

    public void FlashText() {
        cmbm.HideUI();
    }

    public void ShowMoney() {
        cmbm.ShowMoneyAmount(money);
    }

    public int GetMoney() {
        return money;
    }


}
