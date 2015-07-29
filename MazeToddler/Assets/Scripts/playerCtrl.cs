using UnityEngine;
using System.Collections;

public class playerCtrl : MonoBehaviour 
{
    public float Speed;
	public bool isTesting;

	private Animator _animator;
    private Transform _transform;

    private void Awake()
    {
        _transform = this.transform;
        if(this.GetComponent<Animator>())
        {
            _animator = this.GetComponent<Animator>();
        }
    }

    private void testCtrl()
    {
        float fX = Input.GetAxisRaw("Horizontal");
        float fY = Input.GetAxisRaw("Vertical");

        bool bWalking = Mathf.Abs(fX) + Mathf.Abs(fY) > 0;

        _animator.SetBool("IsWalking", bWalking);

        if (bWalking)
        {
            _animator.SetFloat("x", fX);
            _animator.SetFloat("y", fY);

            _transform.position += new Vector3(fX, fY, 0.0f).normalized * Speed * 0.01f;
        }
    }
    private void touchCtrl()
    {
        bool bWalking = InputManager.getInstance().isKeyDown(InputManager.E_INPUT.JoyStick);

        _animator.SetBool("IsWalking", bWalking);

        if (bWalking)
        {
            Vector3 dir = new Vector3(InputManager.getInstance().getTouchManager().getJoyStickDir().x, InputManager.getInstance().getTouchManager().getJoyStickDir().y).normalized;

            float fX = dir.x;
            float fY = dir.y;

            _animator.SetFloat("x", fX);
            _animator.SetFloat("y", fY);


            _transform.position += dir * Time.deltaTime * Speed;
        }
    }

    private void Update()
    {
		if (isTesting)
			testCtrl ();
		else
        	touchCtrl();
    }
    private void OnCollisionEnter2D(Collision2D enterColl)
    {
        GameObject targetObj = enterColl.gameObject;
        if(enterColl.collider.tag == Tags.Item)
        {
            Destroy(targetObj);
        }
    }
}
