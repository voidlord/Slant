using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostGameMenu : MonoBehaviour {
    public Canvas postGameMenu;
    public TextMeshProUGUI scoreTextUI;

    public void SetScoreText(int score) {
        scoreTextUI.text = "Score: " + score;
	}

    public void Show() {
        GetComponent<Canvas>().enabled = true;
	}

    public void Hide() {
        GetComponent<Canvas>().enabled = false;
    }
}
