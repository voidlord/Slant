using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostGameMenu : MonoBehaviour {
    public Canvas postGameMenu;
    public TextMeshProUGUI scoreTextUI;
    public TextMeshProUGUI highScoreTextUI;

    public void SetScoreText(int score, int highScore) {
        scoreTextUI.text = "Score: " + score;
        highScoreTextUI.text = "HighScore: " + highScore;
	}

    public void Show() {
        GetComponent<Canvas>().enabled = true;
	}

    public void Hide() {
        GetComponent<Canvas>().enabled = false;
    }
}
