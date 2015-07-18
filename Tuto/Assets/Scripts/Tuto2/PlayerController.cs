using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 3f;

	private Transform _transform;
	private Rigidbody2D _rigidbody;

	void Awake() {
		_transform = transform;
		_rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if(Input.GetKey (KeyCode.LeftArrow)) {
			_transform.position += Vector3.left * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			_transform.position += Vector3.right * Time.deltaTime * speed;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			_rigidbody.AddForce(Vector2.up*10, ForceMode2D.Impulse);
		}
	}
}
