using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Attach this to a text object to generate a text drop shadow
 */
public class TextDropShadow : MonoBehaviour {

    // Distance down and to the right of the text to have the drop shadow
    private static float OFFSET_DISTANCE = 10f;

    private GameObject dropShadow;
    private Text dsText;
    private Text regText;

    void Start () {
        regText = GetComponent<Text>();
        createText();
	}

    // Keep the drop shadow's text equivalent to the parent's text
    void Update ()
    {
        dsText.text = GetComponent<Text>().text;
    }

    private void createText()
    {
        Vector2 regPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
        
        // TODO: Parent this properly...
        // Create a new text component with only the relevant bits
        dropShadow = new GameObject();
        dropShadow.transform.SetParent(transform);
        dropShadow.AddComponent<Text>();
        dropShadow.AddComponent<RectTransform>();        
        dropShadow.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
        dropShadow.GetComponent<RectTransform>().anchoredPosition = new Vector2(OFFSET_DISTANCE, -OFFSET_DISTANCE);
        dropShadow.transform.localScale = transform.localScale;                
        dropShadow.name = gameObject.name + "DropShadow";       

        // Only modify the text component
        dsText = dropShadow.GetComponent<Text>();
        dsText.color = Color.black;
        dsText.font = regText.font;        
        dsText.text = regText.text;
        dsText.fontSize = regText.fontSize;
    }

}
