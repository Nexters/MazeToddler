using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			SceneStageMgr0.Instance.AcquiredHammer();
			Destroy (gameObject);
		}
	}
}
