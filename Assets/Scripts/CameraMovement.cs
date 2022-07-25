using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameManager gameManager;

    public Transform player;
    public Vector3 offset;

    void Update() {
        if (gameManager.GameState == GameState.Playing) {
            transform.position = player.position + offset;
            transform.rotation = Quaternion.identity;
        } else if (gameManager.GameState == GameState.Ended) {
            transform.LookAt(player.position);
		}
    }
}
