﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/*
 * Responsible for the following:
 *     - Spawns a car that only collides with the pump with the same tag * 
 */
public class Pump : MonoBehaviour {

    // Car field injection 
    public Text moneyTextLabel;
    public Text moneyTextCounter;

    public Text curFuelTextLabel;
    public Text curFuelTextCounter;

    public Image moneyBubble;
    public Image curFuelBubble;


    private float MIN_SPEED = -5.0f;
    private float MAX_SPEED = -12.0f;

    public string pumpTag;
    public CarSpawner carSpawner;

    private GameController gameController;    
    private GameObject currentCar; // Any car that is fueling or moving towards/away from pump    

    void Start() {
        tag = pumpTag;
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        SpawnCar();        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag(tag)) {
            // Stop car and tell gc that it's stopped
            collider.gameObject.GetComponent<Car>().StopCar();
            collider.gameObject.GetComponent<Car>().StartStopwatch();
            collider.gameObject.GetComponent<Car>().ShowMoney();
            gameController.SetCarAtPump(tag, collider.gameObject.GetComponent<Car>());      
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag(tag)) {
            StartCoroutine(Wait());
        }
    }

    // slow car exiting + fast car entering = game crash ;)
    IEnumerator Wait() {
        float randVal = Random.Range(2.0f, 3.5f);
        yield return new WaitForSeconds(randVal);
        SpawnCar();
    }

    public void SpawnCar() {
        int curSortingLayer = int.Parse(GetComponent<SpriteRenderer>().sortingLayerName);
        currentCar = carSpawner.SpawnCar(
            tag, 
            (float) Random.Range(MIN_SPEED, MAX_SPEED),
            (curSortingLayer + 1).ToString()
        );        

        // Inject relevant UI fields
        CarMoneyBubbleManager carUI = currentCar.GetComponent<CarMoneyBubbleManager>();
        carUI.SetMoneyTextLabel(moneyTextLabel);
        carUI.SetMoneyTextCounter(moneyTextCounter);        
        carUI.SetCurFuelTextCounter(curFuelTextCounter);
        carUI.SetMoneyBubble(moneyBubble);        
    }

}
