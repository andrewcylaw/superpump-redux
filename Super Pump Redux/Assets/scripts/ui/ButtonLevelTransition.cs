using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelTransition : MonoBehaviour {

    public void LoadLevel(int num) {
        SceneManager.LoadScene(num);
    }
}
