using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMissEventPublisher
{
    UnityAction MissEvent { get; set;}
}

public class InputManager : MonoBehaviour, IMissEventPublisher
{
    [SerializeField]
    [Header("ON:A押す毎に左右切り替え")]
    [Header("OFF:A押しながらで右、押してないと左")]
    bool _debugInputSwitchType;

    public UnityAction MissEvent { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _wait = 180;
        _orderStack = GetComponent<IGetStack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_debugInputSwitchType)
        {
            _isLeft = !Input.GetButton("ToggleLR");
        }
        else
        {
            if (Input.GetButtonDown("ToggleLR"))
            {
                _isLeft = !_isLeft;
            }
        }

        // fail safe
        if (_orderStack == null) { return; }
        if (0 < _wait)
        {
            --_wait;
            return;
        }

        switch (_orderStack.GetStack(_isLeft))
        {
            case OrderType.Left:
                if (Input.GetButtonDown("left"))
                {
                    _orderStack.Remove(_isLeft);
                    // Debug.Log((_isLeft ? "L" : "R") + " | Left Success");
                }
                else if (Input.GetButtonDown("right")
                    || Input.GetButtonDown("up")
                    || Input.GetButtonDown("down"))
                {
                    MissEvent?.Invoke();
                    // Debug.Log((_isLeft ? "L" : "R") + " | Left Miss");
                }
                break;
            case OrderType.Right:
                if (Input.GetButtonDown("right"))
                {
                    _orderStack.Remove(_isLeft);
                    // Debug.Log((_isLeft ? "L" : "R") + " | Right Success");
                }
                else if (Input.GetButtonDown("left")
                    || Input.GetButtonDown("up")
                    || Input.GetButtonDown("down"))
                {
                    MissEvent?.Invoke();
                    // Debug.Log((_isLeft ? "L" : "R") + " | Right Miss");
                }
                break;
            case OrderType.Up:
                if (Input.GetButtonDown("up"))
                {
                    _orderStack.Remove(_isLeft);
                    // Debug.Log((_isLeft ? "L" : "R") + " | Up Success");
                }
                else if (Input.GetButtonDown("left")
                    || Input.GetButtonDown("right")
                    || Input.GetButtonDown("down"))
                {
                    MissEvent?.Invoke();
                    // Debug.Log((_isLeft ? "L" : "R") + " | Up Miss");
                }
                break;
            case OrderType.Down:
                if (Input.GetButtonDown("down"))
                {
                    _orderStack.Remove(_isLeft);
                    // Debug.Log((_isLeft ? "L" : "R") + " | Down Success");
                }
                else if (Input.GetButtonDown("left")
                    || Input.GetButtonDown("right")
                    || Input.GetButtonDown("up"))
                {
                    MissEvent?.Invoke();
                    // Debug.Log((_isLeft ? "L" : "R") + " | Down Miss");
                }
                break;
        }
    }

    IGetStack _orderStack;
    int _wait;
    bool _isLeft;
}
