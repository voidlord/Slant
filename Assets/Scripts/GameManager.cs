using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    MainMenu, Playing, Ended
}

public class GameManager : MonoBehaviour {
    public PlatformGenerator platformGenerator;
    public PlayerMovement playerMovement;
    public Score scoreUI;
    public Canvas mainMenuUI;
    public PostGameMenu postGameMenuUI;
    public Transform player;

    public int fallDistance = 15;

    GameState gameState;
    int highScore = 0;

    public GameState GameState { get {
            return gameState;
        }
    }

	void Awake() {
        gameState = GameState.MainMenu;

        scoreUI.Hide();
        mainMenuUI.GetComponent<Canvas>().enabled = true;
	}

	void FixedUpdate() {
        if (gameState == GameState.Playing) {
            float playerPos = player.position.y;

            if (platformGenerator.GetSpawnedPlatformsList().Count > 0) {
                int curr = 1;
                if (platformGenerator.GetSpawnedPlatformsList().Count < 2) {
                    curr = 0;
                }
                GameObject currentPlatform = platformGenerator.GetSpawnedPlatformsList()[curr];
                float deadPos = currentPlatform.transform.position.y
                    - currentPlatform.GetComponent<Platform>().yOffset
                    - fallDistance;

                if (playerPos < deadPos) {
                    EndGame();
                }

                if (player.position.z > (currentPlatform.transform.position.z + currentPlatform.GetComponent<Platform>().zOffset)) {
                    platformGenerator.ClearFirstPlatform();
                }
            }
		}
	}

    public void StartGame() {
        mainMenuUI.enabled = false;
        postGameMenuUI.Hide();

        Restart();

        scoreUI.Show();
        gameState = GameState.Playing;
        playerMovement.AllowMovement();
	}

	public void EndGame() {
        if (gameState == GameState.Playing) {
            gameState = GameState.Ended;

            scoreUI.Hide();
            postGameMenuUI.Show();

            int finalScore = scoreUI.GetScore();
            if (finalScore > highScore) {
                highScore = finalScore;
			}

            postGameMenuUI.SetScoreText(finalScore, highScore);
        }
	}

    void Restart() {
        platformGenerator.ClearPlatforms();
        playerMovement.ResetMovement();
	}
}
