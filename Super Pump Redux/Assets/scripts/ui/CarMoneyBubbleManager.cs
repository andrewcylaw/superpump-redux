using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

// Attach this to a car
public class CarMoneyBubbleManager : MonoBehaviour {

    private Text moneyTextLabel;
    private Text moneyTextCounter;

    private Text curFuelTextLabel;
    private Text curFuelTextCounter;

    private Image moneyBubble;
    private Image curFuelBubble;

    // Hides UI after flashing
	public void HideUI() {
        StartCoroutine(Flash());
    }

    // Shows the parts of the UI that were hidden
    public void ShowUI() {
        moneyTextLabel.enabled = true;
        moneyTextLabel.GetComponent<TextDropShadow>().GetDropShadow().GetComponent<Text>().enabled = true;
        moneyTextCounter.enabled = true;
        moneyTextCounter.GetComponent<TextDropShadow>().GetDropShadow().GetComponent<Text>().enabled = true;
        moneyBubble.enabled = true;
    }

    // Forgive me... strapped for time (ugly code + hardcoded)
    IEnumerator Flash() {
        Text moneyTextLabelDropShadow = moneyTextLabel.GetComponent<TextDropShadow>().GetDropShadow().GetComponent<Text>();
        Text moneyTextCounterDropShadow = moneyTextCounter.GetComponent<TextDropShadow>().GetDropShadow().GetComponent<Text>();

        for (int i = 0; i < 3; i++) {
            moneyTextLabel.enabled = true;
            moneyTextLabelDropShadow.enabled = true;
            moneyTextCounter.enabled = true;
            moneyTextCounterDropShadow.enabled = true;
            moneyBubble.enabled = true;
            yield return new WaitForSeconds(0.6f);

            moneyTextLabel.enabled = false;
            moneyTextLabelDropShadow.enabled = false;
            moneyTextCounter.enabled = false;
            moneyTextCounterDropShadow.enabled = false;
            moneyBubble.enabled = false;
            yield return new WaitForSeconds(0.6f);
        }
        moneyTextLabel.enabled = true;
        moneyTextLabelDropShadow.enabled = true;
        moneyBubble.enabled = true;
    }

    public void ShowMoneyAmount(float money) {
        Text moneyTextLabelDropShadow = moneyTextLabel.GetComponent<TextDropShadow>().GetDropShadow().GetComponent<Text>();
        Text moneyTextCounterDropShadow = moneyTextCounter.GetComponent<TextDropShadow>().GetDropShadow().GetComponent<Text>();

        moneyTextLabel.enabled = true;
        moneyTextLabelDropShadow.enabled = true;
        moneyTextCounter.enabled = true;
        moneyTextCounterDropShadow.enabled = true;
        moneyBubble.enabled = true;

        moneyTextCounter.text = money.ToString("C2");
    }

    // Updates text with the correct amounts
    public void ShowFuelAmount(Stopwatch stopwatch) {
        string text = "{0}.{1}";
        curFuelTextCounter.text = string.Format(
            text, 
            stopwatch.Elapsed.Seconds, 
            stopwatch.Elapsed.Milliseconds.ToString("00")); 
    }

    // Injectors since this car is a prefab
    public void SetMoneyTextLabel(Text moneyTextLabel) {
        this.moneyTextLabel = moneyTextLabel;
    }

    public void SetMoneyTextCounter(Text moneyTextCounter) {
        this.moneyTextCounter = moneyTextCounter;
    }

    public void SetCurFuelTextLabel(Text curFuelTextLabel) {
        this.curFuelTextLabel = curFuelTextLabel;
    }

    public void SetCurFuelTextCounter(Text curFuelTextCounter) {
        this.curFuelTextCounter = curFuelTextCounter;
    }

    public void SetMoneyBubble(Image moneyBubble) {
        this.moneyBubble = moneyBubble;
    }

    public void SetCurFuelBubble(Image curFuelBubble) {
        this.curFuelBubble = curFuelBubble;
    }
}
