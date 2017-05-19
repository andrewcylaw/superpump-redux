using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSpawner : MonoBehaviour {

    public Image goodIcon;
    public Image badIcon;

    public Image iconSpawnSpot1;
    public Image iconSpawnSpot2;
    public Image iconSpawnSpot3;
    public Image iconSpawnSpot4;

    // TODO play sound
    public void SpawnGoodIcon(string tag) {
        Image iconSpawnSpot = CheckSpawnSpot(tag);
        Image icon = Instantiate(goodIcon, iconSpawnSpot.GetComponent<Transform>().position, iconSpawnSpot.GetComponent<Transform>().rotation);
        icon.transform.SetParent(iconSpawnSpot.transform);
        icon.GetComponent<AudioSource>().Play();
    }

    public void SpawnBadIcon(string tag) {
        Image iconSpawnSpot = CheckSpawnSpot(tag);
        Image icon = Instantiate(badIcon, iconSpawnSpot.GetComponent<Transform>().position, iconSpawnSpot.GetComponent<Transform>().rotation);
        icon.transform.SetParent(iconSpawnSpot.transform);
        icon.GetComponent<AudioSource>().Play();
    }

    private Image CheckSpawnSpot(string tag) {
        if(tag.Equals("pump1")) {
            return iconSpawnSpot1;
        } else if (tag.Equals("pump2")) {
            return iconSpawnSpot2;
        } else if (tag.Equals("pump3")) {
            return iconSpawnSpot3;
        } else {
            return iconSpawnSpot4;
        }
    }
}
