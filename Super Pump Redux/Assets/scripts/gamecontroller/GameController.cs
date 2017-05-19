using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Mapping of pump tag to bool
    private Dictionary<string, Car> isCarAtPump;
    private PumpSelector pumpSelector;

    // To prevent flickering of axis due to PS4 controller
    private bool axisInUse;

    void Start () {
        axisInUse = false;
        isCarAtPump = new Dictionary<string, Car>();
        pumpSelector = GetComponent<PumpSelector>();
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
            isCarAtPump[curSelectedTag].StartCar();
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
}
