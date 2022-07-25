using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameManager gameManager;
	public Rigidbody rb;

	public float boostAmount = 25;
	public float defaultMaxSpeed = 25;
	public float maxSpeed = 25;
	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;

	void FixedUpdate() {
		if (gameManager.GameState == GameState.Playing) {
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

	void Update() {
		if (gameManager.GameState == GameState.Playing) {
			if (Input.GetKeyDown(KeyCode.LeftShift)) {
				maxSpeed = defaultMaxSpeed * 1 + boostAmount;
			}

			if (Input.GetKeyUp(KeyCode.LeftShift)) {
				maxSpeed = defaultMaxSpeed;
			}

			//Debug.Log(rb.velocity.z + " (" + maxSpeed + " )");
		}
	}

	public void AllowMovement() {
		rb.useGravity = true;
	}

	public void StopMovement() {
		rb.useGravity = false;

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	public void ResetMovement() {
		maxSpeed = defaultMaxSpeed;

		StopMovement();

		rb.transform.position.Set(0, 5, 0);
	}
}
