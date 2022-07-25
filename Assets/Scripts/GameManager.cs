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
    public Transform player;

    int fallDistance = 10;

    GameState gameState;

    public GameState GameState { get {
            return gameState;
        }
    }

	void Awake() {
        gameState = GameState.MainMenu;

        scoreUI.Hide();
	}

	void FixedUpdate() {
        if (gameState == GameState.Playing) {
            float playerPos = player.position.y;

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

    public void StartGame() {
        Restart();

        gameState = GameState.Playing;
        playerMovement.AllowMovement();
        scoreUI.Show();
	}

	public void EndGame() {
        if (gameState == GameState.Playing) {
            gameState = GameState.Ended;

            scoreUI.Hide();
        }
	}

    void Restart() {
        platformGenerator.ClearPlatforms();
        playerMovement.ResetMovement();
	}
}
