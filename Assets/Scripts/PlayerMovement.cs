using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameManager gameManager;
	public GameObject player;
	public Rigidbody rb;

	public Material defaultMaterial;
	public Material boostedMaterial;

	public float boostAmount = 50;
	public float maxSpeed = 25;
	public float defaultMaxSpeed = 25;
	public float forwardForce = 5000;
	public float defaultForwardForce = 5000;
	public float sidewaysForce = 250;

	void Awake() {
		StopMovement();
	}

	void FixedUpdate() {
		if (gameManager.GameState == GameState.Playing) {
			int distance = (int)player.transform.position.z;

			float calculatedMaxSpeed = maxSpeed + Mathf.Sqrt(distance / 100);

			if (rb.velocity.z < calculatedMaxSpeed) {
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
				maxSpeed = defaultMaxSpeed * (1 + boostAmount / 100f);
				forwardForce = defaultForwardForce * (1 + boostAmount / 100f);
				player.GetComponent<Renderer>().material = boostedMaterial;
			}

			if (Input.GetKeyUp(KeyCode.LeftShift)) {
				maxSpeed = defaultMaxSpeed;
				forwardForce = defaultForwardForce;
				player.GetComponent<Renderer>().material = defaultMaterial;
			}
		}
	}

	public void AllowMovement() {
		rb.constraints = RigidbodyConstraints.None;
	}

	public void StopMovement() {
		rb.constraints = RigidbodyConstraints.FreezeAll;

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	public void ResetMovement() {
		maxSpeed = defaultMaxSpeed;

		StopMovement();
		transform.position = new Vector3(0, 5, 0);
		transform.rotation = Quaternion.identity;
	}
}
