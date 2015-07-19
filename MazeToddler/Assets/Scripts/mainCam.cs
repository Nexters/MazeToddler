using UnityEngine;
using System.Collections;

public class mainCam : MonoBehaviour {

	public float Smooth = 4.0f;

	private Transform _transform;
	private Transform _transformPlayer;

	void Awake(){
		_transform = this.transform;
		_transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update(){
		_transform.position = Vector3.Lerp(_transform.position , _transformPlayer.position + Vector3.back, Time.deltaTime + Smooth);
	}
}
