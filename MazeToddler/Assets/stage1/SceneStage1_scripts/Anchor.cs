using UnityEngine;
using System.Collections;

public class Anchor : MonoBehaviour {
	public Transform anchorMovePoint;

	Transform player;
	bool isPlayerCloseEnough;

	void Update() {
		if (!isPlayerCloseEnough)
			return;
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine(PullUpPlayerAnimation());
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			isPlayerCloseEnough = true;
			player = col.transform;
		
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			isPlayerCloseEnough = false;
			player = null;
		}
	}

	IEnumerator PullUpPlayerAnimation() {
		if (player == null)
			yield break;

		SceneStageMgr1.Instance.paused = true;
		player.position = transform.position;
		player.parent = transform;
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (MoveAnchorToDestination ());
		yield return new WaitForSeconds (1.0f);
		IEnumerator fadeout = SceneStageMgr1.Instance._FadeOut ();
		yield return StartCoroutine (fadeout);
		SceneStageMgr1.Instance.paused = false;

	}

	IEnumerator MoveAnchorToDestination() {
		while (transform.position != anchorMovePoint.position) {
			transform.position = Vector3.MoveTowards (transform.position,
			                                          anchorMovePoint.position,
			                                    1.5f * Time.deltaTime);
			yield return null;
		}
	}
}
