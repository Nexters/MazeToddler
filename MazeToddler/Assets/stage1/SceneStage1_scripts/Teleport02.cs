using UnityEngine;
using System.Collections;

public class Teleport02 : MonoBehaviour {
	public Transform teleport02;
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			StartCoroutine (TeleportPlayer(col));
		}
	}
	
	IEnumerator TeleportPlayer(Collider2D player) {
		IEnumerator fadeout = SceneStageMgr1.Instance._FadeOut ();
		yield return StartCoroutine (fadeout);
		player.transform.position = teleport02.position;
		IEnumerator fadein = SceneStageMgr1.Instance._FadeIn ();
		StartCoroutine (fadein);
		
	}
}
