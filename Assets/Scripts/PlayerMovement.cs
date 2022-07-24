using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameManager gameManager;
	public Rigidbody rb;

	public float maxSpeed = 25;
	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;

	void FixedUpdate() {
		if (!gameManager.GameHasEnded) {
			if (rb.velocity.z < maxSpeed) {
				rb.AddForce(0, 0, forwardForce * Time.deltaTime);
			}

			if (Input.GetKey("d")) {
				rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
			}

			if (Input.GetKey("a")) {
				rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
			}
		}
	}
}
