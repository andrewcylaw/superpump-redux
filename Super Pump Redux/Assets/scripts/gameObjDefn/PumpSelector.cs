using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * There are 4 pumps. Please forgive me for hardcoding in positions and ugly code...
 *  
 *    1 | 2
 *    --+--
 *    3 | 4
 * 
 */
public class PumpSelector : MonoBehaviour {

    private string curSelectedTag;
    private Dictionary<Pump, Sprite> deselectedSprites;

    public Pump pump1;
    public Pump pump2;
    public Pump pump3;
    public Pump pump4;

    public Sprite pump1Selected;
    public Sprite pump2Selected;
    public Sprite pump3Selected;
    public Sprite pump4Selected;  

    void Start() {
        deselectedSprites = new Dictionary<Pump, Sprite>();

        deselectedSprites.Add(pump1, pump1.GetComponent<SpriteRenderer>().sprite);
        deselectedSprites.Add(pump2, pump2.GetComponent<SpriteRenderer>().sprite);
        deselectedSprites.Add(pump3, pump3.GetComponent<SpriteRenderer>().sprite);
        deselectedSprites.Add(pump4, pump4.GetComponent<SpriteRenderer>().sprite);

        curSelectedTag = pump1.pumpTag; // safety because pump's tag might not have been initialized yet
        pump1.GetComponent<SpriteRenderer>().sprite = pump1Selected;
    }

    public string GetCurSelectedTag() {
        return curSelectedTag;
    }

    public void MoveRight() {        
        if (curSelectedTag.Equals(pump1.tag)) {
            DeselectAll();
            curSelectedTag = pump2.tag;
            pump2.GetComponent<SpriteRenderer>().sprite = pump2Selected;
        } else if (curSelectedTag.Equals(pump3.tag)) {
            DeselectAll();
            curSelectedTag = pump4.tag;
            pump4.GetComponent<SpriteRenderer>().sprite = pump4Selected;
        }
    }

    public void MoveLeft() {
        if (curSelectedTag.Equals(pump2.tag)) {
            DeselectAll();
            curSelectedTag = pump1.tag;
            pump1.GetComponent<SpriteRenderer>().sprite = pump1Selected;
        } else if (curSelectedTag.Equals(pump4.tag)) {
            DeselectAll();
            curSelectedTag = pump3.tag;
            pump3.GetComponent<SpriteRenderer>().sprite = pump3Selected;
        }
    }

    public void MoveDown() {
        if (curSelectedTag.Equals(pump1.tag)) {
            DeselectAll();
            curSelectedTag = pump3.tag;
            pump3.GetComponent<SpriteRenderer>().sprite = pump3Selected;
        } else if (curSelectedTag.Equals(pump2.tag)) {
            DeselectAll();
            curSelectedTag = pump4.tag;
            pump4.GetComponent<SpriteRenderer>().sprite = pump4Selected;
        }
    }


    public void MoveUp() {        
        if (curSelectedTag.Equals(pump3.tag)) {
            DeselectAll();
            curSelectedTag = pump1.tag;
            pump1.GetComponent<SpriteRenderer>().sprite = pump1Selected;
        } else if (curSelectedTag.Equals(pump4.tag)) {
            DeselectAll();
            curSelectedTag = pump2.tag;
            pump2.GetComponent<SpriteRenderer>().sprite = pump2Selected;
        }
    }

    private void DeselectAll() {
        pump1.GetComponent<SpriteRenderer>().sprite = deselectedSprites[pump1];
        pump2.GetComponent<SpriteRenderer>().sprite = deselectedSprites[pump2];
        pump3.GetComponent<SpriteRenderer>().sprite = deselectedSprites[pump3];
        pump4.GetComponent<SpriteRenderer>().sprite = deselectedSprites[pump4];
    }

}
