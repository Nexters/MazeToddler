using UnityEngine;
using System.Collections;

public class playerCtrl : MonoBehaviour 
{
    public float Speed;
	public bool isTesting;
    public bool canMove = true;
    public bool Stop = false;

    private bool _bAutoMoving = false;
	private Animator _animator;
    private Transform _transform;

	bool reachedGoal;

    private void Awake()
    {
        _transform = this.transform;
        if(this.GetComponent<Animator>())
        {
            _animator = this.GetComponent<Animator>();
        }
		reachedGoal = false;
    }

    private IEnumerator Moving(Vector3 targetPos)
    {
        yield return null;

        _bAutoMoving = true;

        Vector3 dir = targetPos - _transform.position;
        float fRemain = (targetPos - _transform.position).sqrMagnitude;
        _animator.SetBool("IsWalking", true);

        while(!Stop || fRemain * fRemain > 0.1f)
        {
            _animator.SetFloat("x", dir.normalized.x);
            _animator.SetFloat("y", dir.normalized.y);

            _transform.position += dir.normalized * Time.deltaTime * Speed * 5.0f;

            fRemain = (targetPos - _transform.position).sqrMagnitude;
            yield return null;
        }

        _bAutoMoving = false;

        if(!Stop)
            Stop = true;
    }

    public void Move(Vector3 targetPos)
    {
        StartCoroutine(Moving(targetPos));
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

            if (!canMove)
                return;

            _transform.position += new Vector3(fX, fY, 0.0f).normalized * Time.deltaTime * Speed;
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

            if(!canMove)
                return;

            _transform.position += dir * Time.deltaTime * Speed;
        }
    }

    private void Update()
    {
		if (reachedGoal)
			return;

        if (_bAutoMoving)
            return;

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

	public void ReachedGoal() {
		reachedGoal = true;
	}
}
