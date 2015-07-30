using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			SceneStageMgr0.Instance.AcquiredShell();
			Destroy (gameObject);
		}
	}
}
