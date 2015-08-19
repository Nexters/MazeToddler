using UnityEngine;
using System.Collections;

public class StarFish : MonoBehaviour {
	public GameObject mainStarFish;

	bool isPlayerCloseEnough;
	RaycastHit2D hit;

	void Awake() {
		isPlayerCloseEnough = false;
	}

	void Update() {
		if (!isPlayerCloseEnough)
			return;
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			if(hit.collider == GetComponent<Collider2D>()){
				SceneStageMgr1.Instance.PlayerGotStartFish();
				Destroy (mainStarFish);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player"))
			isPlayerCloseEnough = true;
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag.Equals ("Player"))
			isPlayerCloseEnough = false;
	}
}
