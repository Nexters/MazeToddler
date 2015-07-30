using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			if(SceneStageMgr0.Instance.PlayerHasHammer())
				Destroy (gameObject);
		}
	}
}
