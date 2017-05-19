using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Image life1;
    public Image life2;
    public Image life3;

    private int livesLeft;

    void Start() {
        livesLeft = 3;
    }

    public void RemoveLife() {
        if(livesLeft == 1) {
            GetComponent<GameOver>().GameOverCountdown();
            life1.enabled = false;
        } else if (livesLeft == 3) {
            life3.enabled = false;
            livesLeft--;
        } else if (livesLeft == 2) {
            life2.enabled = false;
            livesLeft--;
        }
    }

    public void AddLife() {
        if(livesLeft == 1) {
            livesLeft++;
            life2.enabled = true;
        } else if (livesLeft == 2) {
            livesLeft++;
            life3.enabled = true; ;
        }
    }
}
