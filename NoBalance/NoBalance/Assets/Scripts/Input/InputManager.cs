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
        _orderStack = GetComponent<IGetStack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_debugInputSwitchType)
        {
            _isLeft = !Input.GetButtonDown("ToggleLR");
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

        switch (_orderStack.GetStack(_isLeft))
        {
            case OrderType.Left:
                if (Input.GetButton("left"))
                {
                    _orderStack.Remove(_isLeft);
                }
                else if (Input.GetButton("right")
                    || Input.GetButton("up")
                    || Input.GetButton("down"))
                {
                    MissEvent.Invoke();
                }
                break;
            case OrderType.Right:
                if (Input.GetButton("right"))
                {
                    _orderStack.Remove(_isLeft);
                }
                else if (Input.GetButton("left")
                    || Input.GetButton("up")
                    || Input.GetButton("down"))
                {
                    MissEvent.Invoke();
                }
                break;
            case OrderType.Up:
                if (Input.GetButton("up"))
                {
                    _orderStack.Remove(_isLeft);
                }
                else if (Input.GetButton("left")
                    || Input.GetButton("right")
                    || Input.GetButton("down"))
                {
                    MissEvent.Invoke();
                }
                break;
            case OrderType.Down:
                if (Input.GetButton("down"))
                {
                    _orderStack.Remove(_isLeft);
                }
                else if (Input.GetButton("left")
                    || Input.GetButton("right")
                    || Input.GetButton("up"))
                {
                    MissEvent.Invoke();
                }
                break;
        }
    }

    IGetStack _orderStack;
    bool _isLeft;
}
