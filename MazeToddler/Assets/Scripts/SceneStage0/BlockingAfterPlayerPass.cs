using UnityEngine;
using System.Collections;

public class BlockingAfterPlayerPass : MonoBehaviour {
	public GameObject blockingObject;

	void Awake() {
		blockingObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			PlayerPassed();
		}
	}

	void PlayerPassed() {
		blockingObject.SetActive (true);
	}
}
