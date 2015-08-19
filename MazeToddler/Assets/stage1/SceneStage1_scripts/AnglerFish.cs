using UnityEngine;
using System.Collections;

public class AnglerFish : MonoBehaviour {
	public GameObject hidingObject;
	public GameObject appearedObject;
	public GameObject speechBubble;
	public float pushBackForce;
	public float playerDetectDistance;
	public Sprite happySprite;

	public Transform player;

	CircleCollider2D circleCollider;
	BoxCollider2D boxCollider;
	RaycastHit2D hit;
	Animator anim;

	//bool isPlayerCloseEnough;
	bool isHiding;
	bool showingSpeechBubble;

	void Awake() {
		anim = GetComponent<Animator> ();
		circleCollider = GetComponent<CircleCollider2D> ();
		boxCollider = GetComponent<BoxCollider2D> ();
		HidingAtFirst ();
	}

	void Update() {
		if (isHiding)
			return;
		
		if (PlayerFarAway ()) {
			Hide ();
		}

		//if (!isPlayerCloseEnough)
		//	return;

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			if(hit.collider == appearedObject.GetComponent<Collider2D>()){
				if(SceneStageMgr1.Instance.playerGotStarFish) {
					showingSpeechBubble = true;
					speechBubble.SetActive (true);
					appearedObject.GetComponent<SpriteRenderer>().sprite = happySprite;
					anim.SetTrigger ("Happy");
					//StartCoroutine(_HideAndDestroySelf());
				}
				else {
					StartCoroutine(ShowSpeechBubble());
				}
			}
		}

	}

	public void HideAndDestroySelf() {
		StartCoroutine (_HideAndDestroySelf ());
	}


	public void DestroySelf() {
		Destroy (gameObject);
	}
	IEnumerator _HideAndDestroySelf() {
		Hide ();
		yield return new WaitForSeconds (0.7f);
		Destroy (gameObject);
	}

	bool PlayerFarAway() {
		return Vector3.Distance (transform.position, player.position) > playerDetectDistance;
	}

	IEnumerator ShowSpeechBubble() {
		if (showingSpeechBubble)
			yield break;
		showingSpeechBubble = true;
		speechBubble.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		speechBubble.SetActive (false);
		showingSpeechBubble = false;
	}

	void HidingAtFirst() {
		isHiding = true;
		hidingObject.SetActive (true);
		appearedObject.SetActive (false);
		speechBubble.SetActive (false);
		boxCollider.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			player = col.transform;
			if(isHiding) {
				SceneStageMgr1.Instance.paused = true;
				StartCoroutine(Appear(col));
			} else {
				//isPlayerCloseEnough = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			if(!isHiding) {
				//isPlayerCloseEnough = false;
			}
		}
	}

	public void Hided() {
		hidingObject.SetActive (true);
		appearedObject.SetActive (false);
		circleCollider.enabled = true;
	}

	void Hide() {
		isHiding = true;
		speechBubble.SetActive (false);
		boxCollider.enabled = false;
		anim.SetTrigger ("Hide");
	}

	IEnumerator Appear(Collider2D col) {
		Rigidbody2D playerRigidBody = col.GetComponent<Rigidbody2D> ();	//pushback하기 위함
		isHiding = false;
		hidingObject.SetActive (false);
		appearedObject.SetActive (true);
		anim.SetTrigger ("Appear");
		Vector3 pushBackDir = col.transform.position - appearedObject.transform.position;
		playerRigidBody.AddForce (pushBackDir.normalized * pushBackForce,ForceMode2D.Impulse);
		yield return new WaitForSeconds (1.0f);
		SceneStageMgr1.Instance.paused = false;
		circleCollider.enabled = false;
		boxCollider.enabled = true;
	}

}
