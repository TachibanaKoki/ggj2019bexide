using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    public UnityAction<bool> MissEvent { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _orderStack = transform.parent.Find("SpawnManager").gameObject.GetComponent<IGetStack>();
    }

    // Update is called once per frame
    void Update()
    {
        // fail safe
        if (_orderStack == null) { return; }

        bool isLeft = false;

        switch (_orderStack.GetStack(isLeft))
        {
            case OrderType.Left:
                if (Input.GetButtonDown("left1")||ViveInput.GetDownLeft1())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Left Success");
                }
                else if (Input.GetButtonDown("right1")
                    || Input.GetButtonDown("up1")
                    || Input.GetButtonDown("down1")
                    || ViveInput.GetDownRight1()
                    || ViveInput.GetDownUp1()
                    || ViveInput.GetDownDown1())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Left Miss");
                }
                break;
            case OrderType.Right:
                if (Input.GetButtonDown("right1")|| ViveInput.GetDownRight1())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Right Success");
                }
                else if (Input.GetButtonDown("left1")
                    || Input.GetButtonDown("up1")
                    || Input.GetButtonDown("down1")
                    || ViveInput.GetDownLeft1()
                    || ViveInput.GetDownUp1()
                    || ViveInput.GetDownDown1())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Right Miss");
                }
                break;
            case OrderType.Up:
                if (Input.GetButtonDown("up1")||ViveInput.GetDownUp1())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Up Success");
                }
                else if (Input.GetButtonDown("left1")
                    || Input.GetButtonDown("right1")
                    || Input.GetButtonDown("down1")
                    || ViveInput.GetDownLeft1()
                    || ViveInput.GetDownRight1()
                    || ViveInput.GetDownDown1())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Up Miss");
                }
                break;
            case OrderType.Down:
                if (Input.GetButtonDown("down1")|| ViveInput.GetDownDown1())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Down Success");
                }
                else if (Input.GetButtonDown("left1")
                    || Input.GetButtonDown("right1")
                    || Input.GetButtonDown("up1")
                     || ViveInput.GetDownLeft1()
                    || ViveInput.GetDownRight1()
                    || ViveInput.GetDownUp1())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Down Miss");
                }
                break;
        }

        isLeft = true;

        switch (_orderStack.GetStack(isLeft))
        {
            case OrderType.Left:
                if (Input.GetButtonDown("left2")||ViveInput.GetDownLeft2())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Left Success");
                }
                else if (Input.GetButtonDown("right2")
                    || Input.GetButtonDown("up2")
                    || Input.GetButtonDown("down2")
                    || ViveInput.GetDownUp2()
                    || ViveInput.GetDownRight2()
                    || ViveInput.GetDownDown2())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Left Miss");
                }
                break;
            case OrderType.Right:
                if (Input.GetButtonDown("right2") || ViveInput.GetDownRight2())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Right Success");
                }
                else if (Input.GetButtonDown("left2")
                    || Input.GetButtonDown("up2")
                    || Input.GetButtonDown("down2")
                    || ViveInput.GetDownLeft2()
                    || ViveInput.GetDownUp2()
                    || ViveInput.GetDownDown2())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Right Miss");
                }
                break;
            case OrderType.Up:
                if (Input.GetButtonDown("up2") || ViveInput.GetDownUp2())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Up Success");
                }
                else if (Input.GetButtonDown("left2")
                    || Input.GetButtonDown("right2")
                    || Input.GetButtonDown("down2")
                    || ViveInput.GetDownLeft2()
                    || ViveInput.GetDownRight2()
                    || ViveInput.GetDownDown2())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Up Miss");
                }
                break;
            case OrderType.Down:
                if (Input.GetButtonDown("down2")|| ViveInput.GetDownDown2())
                {
                    _orderStack.Remove(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Down Success");
                }
                else if (Input.GetButtonDown("left2")
                    || Input.GetButtonDown("right2")
                    || Input.GetButtonDown("up2")
                    || ViveInput.GetDownLeft2()
                    || ViveInput.GetDownRight2()
                    || ViveInput.GetDownDown2())
                {
                    MissEvent?.Invoke(isLeft);
                    // Debug.Log((isLeft ? "L" : "R") + " | Down Miss");
                }
                break;
        }

    }

    IGetStack _orderStack;
}
