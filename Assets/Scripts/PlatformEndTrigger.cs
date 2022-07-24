using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEndTrigger : MonoBehaviour {
	public PlatformGenerator platformGenerator;

	void OnTriggerEnter(Collider other) {
		platformGenerator.ClearFirstPlatform();
	}
}
