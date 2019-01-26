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
    private Transform _leftSpawnPostion;
    [SerializeField]
    private Transform _rightSpawnPostion;

    [SerializeField]
    private GameObject _upArrow;
    [SerializeField]
    private GameObject _downArrow;
    [SerializeField]
    private GameObject _rightArrow;
    [SerializeField]
    private GameObject _leftArrow;



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
        switch (orderType)
        {
            case OrderType.Up:
                orderObject._gameObject = GameObject.Instantiate(_upArrow);
                break;
            case OrderType.Down:
                orderObject._gameObject = GameObject.Instantiate(_downArrow);
                break;
            case OrderType.Right:
                orderObject._gameObject = GameObject.Instantiate(_rightArrow);
                break;
            case OrderType.Left:
                orderObject._gameObject = GameObject.Instantiate(_leftArrow);
                break;
        }

        if(isLeft)
        {
            orderObject._gameObject.transform.position = _leftSpawnPostion.position;
            orderObject._gameObject.transform.rotation = _leftSpawnPostion.rotation;
            _leftOrderTypes.Push(orderObject);
        }
        else
        {
            orderObject._gameObject.transform.position = _rightSpawnPostion.position;
            orderObject._gameObject.transform.rotation = _rightSpawnPostion.rotation;
            _leftOrderTypes.Push(orderObject);
        }  
    }
}
