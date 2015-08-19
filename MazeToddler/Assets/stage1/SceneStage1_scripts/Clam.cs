using UnityEngine;
using System.Collections;

public class Clam : MonoBehaviour {

	public GameObject playObject;
	public Transform playerAppearPoint;
	public GameObject playerBubblePrefab;
	public Transform bubble;

	public float bubbleSpeed = 3f;
	public float bubbleLimit_y = 18f;

	Animator anim;
	bool isPlayerTouch = false;
	bool playerClicked = false;
	bool isAnimating = false;

	void Awake() {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (!isAnimating) {
			if(!playerClicked) {
				isAnimating = true;
				anim.SetTrigger ("Open");
			} else {
				playerClicked = false;
				isAnimating = true;
				anim.SetTrigger ("BringPlayer");
			}
		}
	
		if(isPlayerTouch == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				SceneStageMgr1.Instance.paused = true;
				playerClicked = true;
			}

		}		

	}

	public void AnimFinished() {
		StartCoroutine (_AnimFinished ());
	}

	public void HoldPlayer() {
		playObject.transform.SetParent (bubble);
		playObject.transform.localPosition = new Vector3 (0, 0, 0);
	}

	public void LetGoPlayer() {
		bubble.DetachChildren ();
		SceneStageMgr1.Instance.paused = false;
		isPlayerTouch = false;
	}

	IEnumerator _AnimFinished() {
		yield return new WaitForSeconds (1.0f);
		isAnimating = false;
	}

	public void UnEnablePlayerCollider() {
		playObject.GetComponent<CircleCollider2D> ().enabled = false;
	}
	public void EnablePlayerCollider() {
		playObject.GetComponent<CircleCollider2D> ().enabled = true;
	}

	IEnumerator MoveObjTo(Transform obj, Vector3 pos) {
		while (Vector3.Distance (obj.position, pos) > 0.1f) {
			obj.position = Vector3.MoveTowards (obj.position,
			                                    pos,
			                                    bubbleSpeed * Time.deltaTime);
			yield return null;
		}
		
	}

	// baby가 접근시 터치가능
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag.Equals("Player"))
		{
			isPlayerTouch = true;
			playObject = collider.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.tag.Equals("Player"))
		{
			isPlayerTouch = false;
			playObject = null;
		}
	}
}
