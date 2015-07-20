using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    private Transform _transform;
    private Animator _animator;

    void Awake()
    {
        _transform = transform;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            _animator.SetBool("isContact", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _animator.SetBool("isContact", false);
    }
}
