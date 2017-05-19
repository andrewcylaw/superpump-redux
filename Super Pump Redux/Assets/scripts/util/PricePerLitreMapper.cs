using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// yeah yeah it's not really a mapper
public class PricePerLitreMapper : MonoBehaviour {
    private static int LEVEL_1_CARS_REQ = 3;
    private static int LEVEL_2_CARS_REQ = 7;
    private static int LEVEL_3_CARS_REQ = 11;

    private GameController gameController;
	
	void Start () {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
	

    // basically level definition
	public float GetPricePerLitre(int numCarsPassed) {
        if(numCarsPassed < LEVEL_1_CARS_REQ) {
            return 1.0f;
        } else if (numCarsPassed < LEVEL_2_CARS_REQ) {
            return 1.5f;
        } else if (numCarsPassed < LEVEL_3_CARS_REQ) {
            return 1.75f;
        } else {
            return 2.33f;
        }
    }

    
}
