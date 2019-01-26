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
    void GetStackLeft();
    void GetStackRight();
    void RemoveLeft();
    void RemoveRight();
}


public class StackOrder : MonoBehaviour,IGetStack
{
    private Stack<OrderType> _rightOrderTypes  = new Stack<OrderType>();
    private Stack<OrderType> _leftOrderTypes  = new Stack<OrderType>();

    [SerializeField]
    private GameObject _upArrow;
    [SerializeField]
    private GameObject _downArrow;
    [SerializeField]
    private GameObject _RightArrow;
    [SerializeField]
    private GameObject _leftArrow;

    public void GetStackLeft() { }
    public void  GetStackRight() { }
    public void RemoveLeft() { }
    public void RemoveRight() { }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
