using UnityEngine;
using System.Collections;

public class playerCtrl : MonoBehaviour {

	private Transform _transform;
	private Animator _animator;

	void Awake() {
		_transform = this.transform;
		_animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		float fx = Input.GetAxisRaw("Horizontal");
		float fy = Input.GetAxisRaw("Vertical");

		bool bWalking = Mathf.Abs(fx) + Mathf.Abs(fy) > 0;

		_animator.SetBool("IsWalking", bWalking);

        if (bWalking)
        {
            _animator.SetFloat("x", fx);
            _animator.SetFloat("y", fy);

            _transform.position += new Vector3(fx, fy, 0.0f).normalized * 0.03f;
        }
		
	}

	void OnCollisionEnter2D(Collision2D enterColl){

		GameObject targetObi = enterColl.gameObject;
		if(targetObi.tag == "Item"){
			Destroy(targetObi);
		}
	}
}
