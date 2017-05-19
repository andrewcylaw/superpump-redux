using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private GameController gameController;

    public Image bg;
    public Text[] uiElements;

    public Text numGood;
    public Text numBad;

    void Start() {
        Enabled(false);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

	public void GameOverCountdown() {
        gameController.SetGameOver(true);

        numGood.text = gameController.GetNumGood().ToString();
        numBad.text = gameController.GetNumBad().ToString();

        Enabled(true);
        StartCoroutine(CountdownGameover());
    }

    IEnumerator CountdownGameover() {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene(0); // Back to title screen
    }

    private void Enabled(bool en) {
        bg.enabled = en;
        for (int i = 0; i < uiElements.Length; i++) {
            uiElements[i].GetComponent<TextDropShadow>().GetDropShadow().GetComponent<Text>().enabled = en;
            uiElements[i].enabled = en;
        }
    }
}
