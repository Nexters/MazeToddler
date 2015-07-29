using UnityEngine;
using System.Collections;

public class GoalPoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			SceneStageMgr0.Instance.PlayerReachedGoal ();
			NotifyPlayer(col.gameObject);
		}
			
	}

	void NotifyPlayer(GameObject player) {
		player.GetComponent<playerCtrl> ().ReachedGoal ();
	}
}
