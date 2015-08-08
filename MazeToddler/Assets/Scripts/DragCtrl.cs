using UnityEngine;
using System.Collections;

public class DragCtrl : MonoBehaviour 
{
    public Transform Gate;
    public Transform Collider;
    public float MoveSpeed;
    public float AllowGap;
    public Vector3 Goal;

    private InputManager _cInputManager;
    private Transform _transform;
    private Vector2 _vec2Delta;
    private bool _bOpen = false;

    private void Awake()
    {
        _transform = this.transform;
        _vec2Delta = _transform.position;
        _cInputManager = InputManager.getInstance();
    }

    public bool isOpen()
    {
        return _bOpen;
    }
    public void Open()
    {
        _bOpen = true;

        Gate.gameObject.SetActive(false);
        Collider.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_bOpen)
            return;

        if (_cInputManager.isKeyDown(InputManager.E_INPUT.BridgeTouch) && _cInputManager.isKeyDown(InputManager.E_INPUT.Swipe))
        {
            Collider.gameObject.SetActive(false);
            _transform.position = Vector3.Lerp(_transform.position, _cInputManager.getTouchManager().getNowPos(), Time.deltaTime * MoveSpeed);
        }

        float fGap = (Goal - _transform.position).sqrMagnitude;

        if(!_bOpen)
        {
            if(!_cInputManager.isKeyDown(InputManager.E_INPUT.Swipe))
            {
                if (fGap * fGap > AllowGap)
                {
                    _transform.position = Vector3.Lerp(_transform.position, _vec2Delta, Time.deltaTime * MoveSpeed);
                    Collider.gameObject.SetActive(true);
                }
                else
                {
                    _transform.position = Vector3.Lerp(_transform.position, Goal, Time.deltaTime * MoveSpeed);
                    if (_transform.position != Goal)
                        return;
                    Open();
                }
            }
        }
        
    }
}
