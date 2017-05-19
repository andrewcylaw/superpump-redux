using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// yeah yeah it's not really a mapper
public class PricePerLitreMapper : MonoBehaviour {
    private static int LEVEL_1_CARS_REQ = 3;
    private static int LEVEL_2_CARS_REQ = 7;
    private static int LEVEL_3_CARS_REQ = 11;

    public Text pplText;

    private GameController gameController;
	
	void Start () {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
	

    // basically level definition + setting the text
	public float GetPricePerLitre(int numCarsPassed) {
        float ppl;
        if(numCarsPassed < LEVEL_1_CARS_REQ) {
            ppl = 1.0f;
        } else if (numCarsPassed < LEVEL_2_CARS_REQ) {
            ppl = 1.5f;
        } else if (numCarsPassed < LEVEL_3_CARS_REQ) {
            ppl = 1.75f;
        } else {
            ppl = 2.33f;
        }
        SetPPLText(ppl);
        return ppl;
    }

    private void SetPPLText(float price) {
        pplText.text = price.ToString("C2") + "/L";
    }
    
}
