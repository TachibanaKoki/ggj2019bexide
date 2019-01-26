using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    Up,
    Down,
    Right,
    Left
}

public interface IGetStack
{
    OrderType GetStack(bool isLeft);
    void Remove(bool isLeft);
}

public class OrderObject
{
    public GameObject _gameObject;
    public OrderType _orderType;
}


public class StackOrder : MonoBehaviour,IGetStack
{
    private Stack<OrderObject> _rightOrderTypes  = new Stack<OrderObject>();
    private Stack<OrderObject> _leftOrderTypes  = new Stack<OrderObject>();

    [SerializeField]
    private float _leftInstanceInterval = 1.0f;
    [SerializeField]
    private float _rightInstanceInterval = 1.0f;

    [SerializeField]
    private GameObject _rightUpArrow;
    [SerializeField]
    private GameObject _rightDownArrow;
    [SerializeField]
    private GameObject _rightRightArrow;
    [SerializeField]
    private GameObject _rightLeftArrow;

    [SerializeField]
    private GameObject _leftUpArrow;
    [SerializeField]
    private GameObject _leftDownArrow;
    [SerializeField]
    private GameObject _leftRightArrow;
    [SerializeField]
    private GameObject _leftLeftArrow;

    public void Start()
    {
        StartCoroutine(LeftLaneInstance());
        StartCoroutine(RightLaneInstance());
    }

    IEnumerator LeftLaneInstance()
    {
        while(true)
        {
            OrderInstance((OrderType)Random.Range(0,4),true);
            yield return new WaitForSeconds(_leftInstanceInterval);
        }
    }

    IEnumerator RightLaneInstance()
    {
       while(true)
        {
            OrderInstance((OrderType)Random.Range(0, 4), false);
            yield return new WaitForSeconds(_rightInstanceInterval);
        }
    }

    public OrderType GetStack(bool isleft)
    {
        if (isleft)
        {
            return _leftOrderTypes.Peek()._orderType;
        }
        else
        {
            return _rightOrderTypes.Peek()._orderType;
        }
    }

    public void Remove(bool isLeft)
    {
        if (isLeft)
        {
            GameObject.Destroy(_leftOrderTypes.Pop()._gameObject);
        }
        else
        {
            GameObject.Destroy(_rightOrderTypes.Pop()._gameObject);
        }
    }

    private void OrderInstance(OrderType orderType,bool isLeft)
    {
        OrderObject orderObject = new OrderObject();
        orderObject._orderType = orderType;


        if(isLeft)
        {
            switch (orderType)
            {
                case OrderType.Up:
                    orderObject._gameObject = GameObject.Instantiate(_leftUpArrow);
                    break;
                case OrderType.Down:
                    orderObject._gameObject = GameObject.Instantiate(_leftDownArrow);
                    break;
                case OrderType.Right:
                    orderObject._gameObject = GameObject.Instantiate(_leftRightArrow);
                    break;
                case OrderType.Left:
                    orderObject._gameObject = GameObject.Instantiate(_leftLeftArrow);
                    break;
            }
            orderObject._gameObject.SetActive(true);
            //orderObject._gameObject.AddComponent<Rigidbody>();
            _leftOrderTypes.Push(orderObject);
        }
        else
        {
            switch (orderType)
            {
                case OrderType.Up:
                    orderObject._gameObject = GameObject.Instantiate(_rightUpArrow);
                    break;
                case OrderType.Down:
                    orderObject._gameObject = GameObject.Instantiate(_rightDownArrow);
                    break;
                case OrderType.Right:
                    orderObject._gameObject = GameObject.Instantiate(_rightRightArrow);
                    break;
                case OrderType.Left:
                    orderObject._gameObject = GameObject.Instantiate(_rightLeftArrow);
                    break;
            }
            orderObject._gameObject.SetActive(true);
            //orderObject._gameObject.AddComponent<Rigidbody>();
            _rightOrderTypes.Push(orderObject);
        }  
    }
}
