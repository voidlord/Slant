using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameManager gameManager;

    public Transform player;
    public Vector3 offset;

    void Update() {
        if (!gameManager.GameHasEnded) {
            transform.position = player.position + offset;
        } else {
            transform.LookAt(player.position);
		}
    }
}
