using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private StackOrder _orderStack;

    public void Start()
    {
        _inputManager.MissEvent += this.MissPenalty;
    }

    public void MissPenalty(bool isLeft)
    {
        _orderStack.SetPenalty(isLeft);
        // _orderStack.OrderInstance((OrderType)Random.Range(0, 4), isLeft, -2.0f);
        // _orderStack.OrderInstance((OrderType)Random.Range(0, 4), isLeft, -1.0f);
        // _orderStack.OrderInstance((OrderType)Random.Range(0, 4), isLeft, 0.0f);
    }
}