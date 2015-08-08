using UnityEngine;
using System.Collections;

public class SwipeCtrl : MonoBehaviour 
{
    public float OpenDistance;
    public GameObject Item;
    public Transform SwipeTargetLeft;
    public Transform SwipeTargetRight;
    public Transform Collider;
    public float ObjectMoveSpeed;

    private bool _bOpen = false;
    private bool _bOpenStart = false;
    private Vector3 _vec3InitPosLeft;
    private Vector3 _vec3InitPosRight;

    public bool IsOpen()
    {
        return _bOpen;
    }

    private void Awake()
    {
        _vec3InitPosLeft = SwipeTargetLeft.position;
        _vec3InitPosRight = SwipeTargetRight.position;
    }
    private void open()
    {
        GameObject newItem = Instantiate(Item);
        newItem.transform.position = transform.position;
        _bOpenStart = true;
        Collider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_bOpen && !InputManager.getInstance().isKeyDown(InputManager.E_INPUT.SwipeTouch))
            return;

        float fDragDistanceX = InputManager.getInstance().getTouchManager().getDistanceX();
        float fDragDistanceY = InputManager.getInstance().getTouchManager().getDistanceY();
        Vector3 OpenPos = new Vector3(OpenDistance, 0.0f, 0.0f);

        if (SwipeTargetLeft.position.x < (_vec3InitPosLeft - OpenPos).x && SwipeTargetRight.position.x > (_vec3InitPosRight + OpenPos).x)
            _bOpen = true;

        if (!_bOpen && !_bOpenStart && Mathf.Abs(fDragDistanceX) + Mathf.Abs(fDragDistanceY) > OpenDistance)
            open();

        if(_bOpenStart)
        {
            SwipeTargetLeft.position = Vector3.Lerp(SwipeTargetLeft.position, _vec3InitPosLeft - OpenPos * 0.1f, Time.deltaTime * ObjectMoveSpeed);
            SwipeTargetRight.position = Vector3.Lerp(SwipeTargetRight.position, _vec3InitPosRight + OpenPos * 0.1f, Time.deltaTime * ObjectMoveSpeed);
        }

//         if (!_bOpen && fDragDistanceX > OpenDistance)
//             open();
//         if(!_bOpen && InputManager.getInstance().isKeyDown(InputManager.E_INPUT.Swipe))
//         {
//             if (fDragDistanceX > OpenDistance)
//                 fDragDistanceX = OpenDistance;
// 
//             if(fDragDistanceX > 0)
//             {
//                 SwipeTargetLeft.position = _vec3InitPosLeft + new Vector3(-fDragDistanceX, 0.0f, 0.0f) * Time.deltaTime * ObjectMoveSpeed;
//                 SwipeTargetRight.position = _vec3InitPosRight + new Vector3(fDragDistanceX, 0.0f, 0.0f) * Time.deltaTime * ObjectMoveSpeed;
//             }
//             if(fDragDistanceX < 0)
//             {
//                 if(SwipeTargetLeft.position.x < _vec3InitPosLeft.x)
//                     SwipeTargetLeft.position = _vec3InitPosLeft + new Vector3(-fDragDistanceX, 0.0f, 0.0f) * Time.deltaTime * ObjectMoveSpeed;
//                 if (SwipeTargetRight.position.x > _vec3InitPosRight.x)
//                     SwipeTargetRight.position = _vec3InitPosRight + new Vector3(fDragDistanceX, 0.0f, 0.0f) * Time.deltaTime * ObjectMoveSpeed;
//             }
//            
//         }
// 
//         if(!_bOpen && !InputManager.getInstance().isKeyDown(InputManager.E_INPUT.Swipe))
//         {
//             if (SwipeTargetLeft.position != _vec3InitPosLeft)
//                 SwipeTargetLeft.position = Vector3.Lerp(SwipeTargetLeft.position, _vec3InitPosLeft, Time.deltaTime * ObjectMoveSpeed * 0.5f);
//             if (SwipeTargetRight.position != _vec3InitPosRight)
//                 SwipeTargetRight.position = Vector3.Lerp(SwipeTargetRight.position, _vec3InitPosRight, Time.deltaTime * ObjectMoveSpeed * 0.5f);
//         }
    }
}
