using UnityEngine;
using System.Collections;

public class MovingFloor : MonoBehaviour {
	public GameObject rightDoor;
	public GameObject leftDoor;
	public float speed;

	Animator anim;

	bool isRight = true;
	bool isMoving = false;

	void Awake() {
		anim = GetComponent<Animator> ();
	}

	void Update() {
		if (isMoving) {
			CloseDoors();
			return;
		}

		if (isRight) {
			OpenRightDoor ();
		} else {
			OpenLeftDoor();
		}
	}

	void CloseDoors() {
		rightDoor.SetActive (true);
		leftDoor.SetActive (true);
	}

	void OpenRightDoor() {
		if (!rightDoor.activeSelf)
			return;

		rightDoor.SetActive (false);
		leftDoor.SetActive (true);
	}

	void OpenLeftDoor() {
		if (!leftDoor.activeSelf)
			return;

		leftDoor.SetActive (false);
		rightDoor.SetActive (true);
	}

	void CloseDoorsAndMove() {
		CloseDoors ();
		isMoving = true;
		if (isRight) {
			StartCoroutine (ToLeft());
		} else {
			StartCoroutine (ToRight());
		}

	}

	IEnumerator ToLeft() {
		Vector3 goal = new Vector3 (1.37f, -9.22f, 1f);
		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, goal, Time.deltaTime*speed);
			if(transform.position == goal)
				break;
			yield return new WaitForEndOfFrame();
		}
		ReachedLeft ();

	}

	IEnumerator ToRight() {
		Vector3 goal = new Vector3 (2.94f, -8.65f, 1f);
		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, goal, Time.deltaTime*speed);
			if(transform.position == goal)
				break;
			yield return new WaitForEndOfFrame();
		}
		ReachedRight ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (isMoving)
			return;

		if (col.tag.Equals ("Player")) {
			CloseDoorsAndMove();
		}
	}

	void ReachedRight() {
		isRight = true;
		isMoving = false;
	}

	void ReachedLeft() {
		isRight = false;
		isMoving = false;
	}
}
