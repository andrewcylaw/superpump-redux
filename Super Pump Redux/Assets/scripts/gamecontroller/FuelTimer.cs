using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class FuelTimer : MonoBehaviour {

    private Stopwatch fuelStopwatch;

    public FuelTimer() {
        this.fuelStopwatch = new Stopwatch();
    }

    public void StartTimer() {
        if (!fuelStopwatch.IsRunning) {
            this.fuelStopwatch.Start();
        } else {
            this.fuelStopwatch.Reset();
        }
    }

    public void StopTimer() {
        this.fuelStopwatch.Stop();
    }

}
