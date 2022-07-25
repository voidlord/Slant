using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
	public GameManager gameManager;
	public Transform playerPos;
	public TextMeshProUGUI scoreUIText;

	public int unitPerScore = 40;
	int score;

	void Update() {
		if (gameManager.GameState == GameState.Playing) {
			score = (int)playerPos.position.z / unitPerScore;
			scoreUIText.text = score.ToString();
		}
	}

	public void Show() {
		GetComponent<Canvas>().enabled = true;
	}

	public void Hide() {
		GetComponent<Canvas>().enabled = false;
	}

	public int GetScore() {
		return score;
	}
}
