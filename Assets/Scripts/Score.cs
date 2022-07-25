using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
	public GameManager gameManager;
	public TextMeshProUGUI scoreUIText;

	System.DateTime startTime;

	void Awake() {
		ResetTimer();
	}

	void Update() {
		if (gameManager.GameState == GameState.Playing) {
			if (startTime == System.DateTime.MinValue) {
				scoreUIText.text = "0";
			} else {
				scoreUIText.text = GetTime().ToString();
			}
		}
	}

	public void Show() {
		GetComponent<Canvas>().enabled = true;
	}

	public void Hide() {
		GetComponent<Canvas>().enabled = false;
	}

	public void StartTimer() {
		startTime = System.DateTime.UtcNow;
	}

	public int GetTime() {
		System.TimeSpan timeSpan = System.DateTime.UtcNow - startTime;

		return timeSpan.Seconds;
	}

	public void ResetTimer() {
		startTime = System.DateTime.MinValue;
	}
}
