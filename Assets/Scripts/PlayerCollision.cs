using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	public GameManager gameManager;

	private void OnCollisionEnter(UnityEngine.Collision collision) {
		Vector3 hit = collision.GetContact(0).normal;
		float angle = Vector3.Angle(hit, Vector3.back);

		if (Mathf.Approximately(angle, 0)) {
			gameManager.EndGame();
		}

		if (collision.collider.tag == "Obstacle") {
			Debug.Log("Obstacle Hit");
		}
	}
}
