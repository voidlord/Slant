using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public PlatformGenerator platformGenerator;
    public Transform player;

    int fallDistance = 10;

    bool gameHasEnded = false;

    public bool GameHasEnded { get {
            return gameHasEnded;
        }
    }

	void FixedUpdate() {
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
	}

	public void EndGame() {
        if (gameHasEnded == false) {
            gameHasEnded = true;

            Debug.Log("Game over");

            //Restart();
        }
	}

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
