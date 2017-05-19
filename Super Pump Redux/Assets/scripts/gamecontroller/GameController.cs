using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Mapping of pump tag to bool
    private Dictionary<string, Car> isCarAtPump;
    private PumpSelector pumpSelector;

    // To prevent flickering of axis due to PS4 controller
    private bool axisInUse;

    private int numGood;

    void Start () {
        numGood = 0;
        axisInUse = false;
        isCarAtPump = new Dictionary<string, Car>();
        pumpSelector = GetComponent<PumpSelector>();

        GetComponent<PricePerLitreMapper>().GetPricePerLitre(numGood);
    }
	
	void Update () {       

        axisInUse = false;

        if(!axisInUse) {
            if (Input.GetAxisRaw("PS4_x") == 1) {
                MoveCar();
            } if (Input.GetAxisRaw("PS4_dpad_x") == 1) {
                pumpSelector.MoveRight();
                axisInUse = true;
            } else if (Input.GetAxisRaw("PS4_dpad_x") == -1) {
                pumpSelector.MoveLeft();
                axisInUse = true;
            } else if (Input.GetAxisRaw("PS4_dpad_y") == 1) {
                pumpSelector.MoveUp();
                axisInUse = true;
            } else if (Input.GetAxisRaw("PS4_dpad_y") == -1) {
                pumpSelector.MoveDown();
                axisInUse = true;
            }
        }               
    }   


    // If car is parked and the player currently has this pump selected, send the car away
    private void MoveCar() {
        string curSelectedTag = pumpSelector.GetCurSelectedTag();
        if (isCarAtPump.ContainsKey(curSelectedTag)) {            
            Car car = isCarAtPump[curSelectedTag];
            car.StartCar();
            car.StopStopwatch();
            car.FlashText();

            // Arbitrary destruction time
            Destroy(car, 6.0f);
            CalculateScore(car, car.GetStopwatch());
            RemoveCarFromPump(car.tag);         
        }
    }


    // tells gamecontroller that there is currently a car at pump identified by tag
    public void SetCarAtPump(string tag, Car car) {
        isCarAtPump.Add(tag, car);
    }

    // remove the car from the pump
    private void RemoveCarFromPump(string tag) {
        isCarAtPump.Remove(tag);
    }

    private void CalculateScore(Car car, Stopwatch stopwatch) {
        float pricePerLitre = GetComponent<PricePerLitreMapper>().GetPricePerLitre(numGood);

        UnityEngine.Debug.Log("stopwatch elapsed seconds: " + ((float)stopwatch.Elapsed.TotalSeconds));
        UnityEngine.Debug.Log("car money: " + car.GetMoney());
        UnityEngine.Debug.Log("ppl: " + pricePerLitre);


        float proximity = Mathf.Abs(car.GetMoney() - ((float) stopwatch.Elapsed.TotalSeconds) * pricePerLitre);

        if(proximity < 1.25) {
            numGood++;
            GetComponent<IconSpawner>().SpawnGoodIcon(car.tag);
        } else {
            GetComponent<IconSpawner>().SpawnBadIcon(car.tag);
        }

        UnityEngine.Debug.Log("Car with tag: " + car.tag + " has a proximitiy of " + proximity);
    }


}
