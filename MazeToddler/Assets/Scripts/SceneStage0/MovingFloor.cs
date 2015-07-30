using UnityEngine;
using System.Collections;

public class MovingFloor : MonoBehaviour 
{
	public GameObject rightDoor;
	public GameObject leftDoor;
	public float speed;

    private Transform _transformPlayerPool;
    private Transform _transformPlayer;

	Animator anim;

	bool isRight = true;
	bool isMoving = false;

	void Awake() 
    {
        _transformPlayerPool = GameObject.Find("Player").transform;
        _transformPlayer = GameObject.FindGameObjectWithTag(Tags.Player).transform;
		anim = GetComponent<Animator> ();
	}

	void Update() {
		if (isMoving) 
        {
            _transformPlayer.parent = this.gameObject.transform;
			CloseDoors();
			return;
		}
        

		if (isRight) 
        {
			OpenRightDoor ();
		} 
        else 
        {
			OpenLeftDoor();
		}

        if (!isMoving && _transformPlayer.parent != _transformPlayerPool)
            _transformPlayer.parent = _transformPlayerPool;
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
			yield return null;
		}
		ReachedLeft ();

	}

	IEnumerator ToRight() {
		Vector3 goal = new Vector3 (2.94f, -8.65f, 1f);
		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, goal, Time.deltaTime*speed);
			if(transform.position == goal)
				break;
			yield return null;
		}
		ReachedRight ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (isMoving)
			return;

		if (col.tag == Tags.Player)
        {
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
