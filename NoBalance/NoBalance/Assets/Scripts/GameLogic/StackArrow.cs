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


public class StackOrder : MonoBehaviour
{
    public List<OrderType> _rightOrderTypes { get; private set; } = new List<OrderType>();
    public List<OrderType> _LeftOrderTypes { get; private set; } = new List<OrderType>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
