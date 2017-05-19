using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Attach this to a text object to generate a text drop shadow
 */
public class TextDropShadow : MonoBehaviour {

    // Distance down and to the right of the text to have the drop shadow
    public float offsetDistance;

    private GameObject dropShadow;
    private Text dsText;
    private Text regText;

    void Awake() {
        regText = GetComponent<Text>();
        createText();
    }

    // Keep the drop shadow's text equivalent to the parent's text
    void Update() {
        dsText.text = GetComponent<Text>().text;
    }

    private void createText() {
        Vector2 regPos = gameObject.GetComponent<RectTransform>().anchoredPosition;

        // Create a new text component with only the relevant bits
        dropShadow = new GameObject();
        dropShadow.transform.SetParent(transform);
        dropShadow.AddComponent<Text>();
        dropShadow.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
        dropShadow.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetDistance, -offsetDistance);

        dropShadow.transform.localScale = transform.localScale;
        dropShadow.name = gameObject.name + "DropShadow";

        // Reverse the parenting of the text objects to place the shadow under the text
        dropShadow.transform.SetParent(transform.parent);
        transform.SetParent(dropShadow.transform);

        // Only modify the text component
        dsText = dropShadow.GetComponent<Text>();
        dsText.color = Color.black;
        dsText.font = regText.font;
        dsText.text = regText.text;
        dsText.fontSize = regText.fontSize;
    }

    public GameObject GetDropShadow() {
        return this.dropShadow;
    }

}
