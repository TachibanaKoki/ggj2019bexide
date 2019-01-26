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
    OrderType GetStackLeft();
    OrderType GetStackRight();
    void RemoveLeft();
    void RemoveRight();
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
    private GameObject _upArrow;
    [SerializeField]
    private GameObject _downArrow;
    [SerializeField]
    private GameObject _RightArrow;
    [SerializeField]
    private GameObject _leftArrow;

    public OrderType GetStackLeft()
    {
        return _leftOrderTypes.Peek()._orderType;
    }

    public OrderType GetStackRight()
    {
        return _rightOrderTypes.Peek()._orderType;
    }

    public void RemoveLeft()
    {
        GameObject.Destroy(_leftOrderTypes.Peek()._gameObject);
    }
    public void RemoveRight()
    {
        GameObject.Destroy(_rightOrderTypes.Peek()._gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
