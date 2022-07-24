using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
	public PlayerMovement movement;

	private void OnCollisionEnter(UnityEngine.Collision collision) {
		if (collision.collider.tag == "Obstacle") {
			movement.enabled = false;
		}
	}
}
