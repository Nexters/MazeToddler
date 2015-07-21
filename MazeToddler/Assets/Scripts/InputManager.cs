using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public enum E_INPUT
    {
        JoyStick,
        Swipe,
        Touch,
        Max
    }
    static private InputManager _instance = null;
    private InputManager()
    {
    }
    public static InputManager getInstance()
    {
        if (!_instance)
        {
            GameObject newInstance;
            newInstance = new GameObject("InputManager");
            _instance = newInstance.AddComponent<InputManager>();
        }

        return _instance;
    }
    private void Awake()
    {
        _cTouchManager.init();
    }
    private void Update()
    {
        _cTouchManager.update();
    }

    private TouchManager _cTouchManager = new TouchManager();
    private bool[] _bInputData = new bool[(int)E_INPUT.Max];
    public void keyDown(E_INPUT eType)
    {
        _bInputData[(int)eType] = true;
    }
    public void keyUp(E_INPUT eType)
    {
        _bInputData[(int)eType] = false;
    }
    public bool isKeyDown(E_INPUT eType)
    {
        return _bInputData[(int)eType];
    }
    public TouchManager getTouchManager()
    {
        return _cTouchManager;
    }
    
}

public class TouchManager
{
    private const string strBegan = "Begin";
    private const string strMove = "Move";
    private const string strEnd = "End";

    private Camera _mainCam;

    delegate void eventListener(string strType, float fX, float fY, float fDistanceX, float fDistanceY);

    private eventListener _listenerBegan;
    private eventListener _listenerMoved;
    private eventListener _listenerEnded;

    private Vector2 _vec2DeltaPos;
    private Vector2 _vec2JoyStickDir;
    private bool _bInteracting;

    public void init()
    {
        _mainCam = Camera.main;
        _listenerBegan = onTouch;
        _listenerMoved = onTouch;
        _listenerEnded = onTouch;
    }

    private void onTouch(string strType, float fX, float fY, float fDistanceX, float fDistanceY)
    {
        switch (strType)
        {
            case strBegan:
                {
                    Ray rayScreen = _mainCam.ScreenPointToRay(new Vector3(fX, fY, 0.0f));
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(rayScreen, out hitInfo))
                    {
                        _bInteracting = true;

                        if (!InputManager.getInstance().isKeyDown(InputManager.E_INPUT.Touch))
                            InputManager.getInstance().keyDown(InputManager.E_INPUT.Touch);
                    }

                }
                break;
            case strMove:
                {
                    if (!_bInteracting)
                    {
                        if (!InputManager.getInstance().isKeyDown(InputManager.E_INPUT.JoyStick))
                            InputManager.getInstance().keyDown(InputManager.E_INPUT.JoyStick);

                        Vector2 vec2JSdir = new Vector2(fDistanceX, fDistanceY);
                        _vec2JoyStickDir = vec2JSdir;
                    }
                }
                break;
            case strEnd:
                {
                    if (_bInteracting)
                        _bInteracting = false;

                    if (InputManager.getInstance().isKeyDown(InputManager.E_INPUT.Touch))
                        InputManager.getInstance().keyUp(InputManager.E_INPUT.Touch);

                    if (InputManager.getInstance().isKeyDown(InputManager.E_INPUT.JoyStick))
                        InputManager.getInstance().keyUp(InputManager.E_INPUT.JoyStick);
                }
                break;
        }
    }

    public void update()
    {
        int nTouchCount = Input.touchCount;
        if (nTouchCount == 0)
            return;


        for (int i = 0; i < nTouchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            Vector2 vec2TouchPos = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                _vec2DeltaPos = vec2TouchPos;
            }

            float fX = 0.0f;
            float fY = 0.0f;
            float fDistanceX = 0.0f;
            float fDistanceY = 0.0f;

            fX = vec2TouchPos.x;
            fY = vec2TouchPos.y;
            if (touch.phase == TouchPhase.Began)
            {
                fDistanceX = 0.0f;
                fDistanceY = 0.0f;
            }
            else
            {
                fDistanceX = vec2TouchPos.x - _vec2DeltaPos.x;
                fDistanceY = vec2TouchPos.y - _vec2DeltaPos.y;
            }

            if (touch.phase == TouchPhase.Began)
            {
                _listenerBegan(strBegan, fX, fY, fDistanceX, fDistanceY);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _listenerMoved(strMove, fX, fY, fDistanceX, fDistanceY);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _listenerEnded(strEnd, fX, fY, fDistanceX, fDistanceY);
            }
        }
            
    }

    public Vector2 getJoyStickDir()
    {
        return _vec2JoyStickDir;
    }
    public bool isInteracting()
    {
        return _bInteracting;
    }
}
