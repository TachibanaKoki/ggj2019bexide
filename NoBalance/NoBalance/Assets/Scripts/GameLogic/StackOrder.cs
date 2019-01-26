using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    Up,
    Down,
    Right,
    Left,
    NULL
}

public interface IGetStack
{
    OrderType GetStack(bool isLeft);
    void Remove(bool isLeft);
    void OrderInstance(OrderType orderType, bool isLeft,float offset);
}

public class OrderObject
{
    public GameObject _gameObject;
    public OrderType _orderType;
}


public class StackOrder : MonoBehaviour,IGetStack
{
    private Queue<OrderObject> _rightOrderTypes  = new Queue<OrderObject>();
    private Queue<OrderObject> _leftOrderTypes  = new Queue<OrderObject>();

    [SerializeField]
    private Transform _leftSpawn;
    [SerializeField]
    private Transform _rightSpawn;

    [SerializeField]
    private float _leftInstanceInterval = 1.0f;
    [SerializeField]
    private float _rightInstanceInterval = 1.0f;
    [SerializeField]
    [Header("ペナルティで何個分生成を早くするか")]
    private int _penaltyNum;
    [SerializeField]
    [Header("ペナルティで何秒早く出すか")]
    private float _penaltyInterval;

    [SerializeField]
    private GameObject _upArrow;
    [SerializeField]
    private GameObject _downArrow;
    [SerializeField]
    private GameObject _rightArrow;
    [SerializeField]
    private GameObject _leftArrow;

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
            float interval = _leftInstanceInterval;
            if (0 < _penaltyRestNumLeft) {
                --_penaltyRestNumLeft;
                interval -= _penaltyInterval;
                Debug.Log("Left: rest " + _penaltyRestNumLeft + " interval " + interval);
            }
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator RightLaneInstance()
    {
       while(true)
        {
            OrderInstance((OrderType)Random.Range(0, 4), false);
            float interval = _rightInstanceInterval;
            if (0 < _penaltyRestNumRight) {
                --_penaltyRestNumRight;
                interval -= _penaltyInterval;
                Debug.Log("Right: rest " + _penaltyRestNumLeft + " interval " + interval);
            }
            yield return new WaitForSeconds(interval);
        }
    }

    public OrderType GetStack(bool isleft)
    {
        if (isleft)
        {
            if (_leftOrderTypes.Count <= 0) return OrderType.NULL;
            OrderObject oo =   _leftOrderTypes.Peek();
            if (oo._gameObject.GetComponent<Arrow>()._isGround)
            {
                return oo._orderType;
            }
            else
            {
                return OrderType.NULL;
            }
        }
        else
        {
            if (_rightOrderTypes.Count <= 0) return OrderType.NULL;
            OrderObject oo = _rightOrderTypes.Peek();
            if (oo._gameObject.GetComponent<Arrow>()._isGround)
            {
                return oo._orderType;
            }
            else
            {
                return OrderType.NULL;
            }
        }
    }

    public void Remove(bool isLeft)
    {
        if (isLeft)
        {
            if (_leftOrderTypes.Count <= 0) return;
            GameObject.Destroy(_leftOrderTypes.Dequeue()._gameObject);
        }
        else
        {
            if (_rightOrderTypes.Count <= 0) return;
            GameObject.Destroy(_rightOrderTypes.Dequeue()._gameObject);
        }
    }

    public void OrderInstance(OrderType orderType,bool isLeft,float Offset = 0)
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

        if (isLeft)
        {
            orderObject._gameObject.transform.position = _leftSpawn.position + new Vector3(0,Offset,0);
            orderObject._gameObject.transform.rotation = _leftSpawn.rotation;
            orderObject._gameObject.SetActive(true);
            _leftOrderTypes.Enqueue(orderObject);
        }
        else
        {
            orderObject._gameObject.transform.position = _rightSpawn.position + new Vector3(0, Offset, 0);
            orderObject._gameObject.transform.rotation = _rightSpawn.rotation;
            orderObject._gameObject.SetActive(true);
            _rightOrderTypes.Enqueue(orderObject);
        }  
    }

    public void SetPenalty(bool isLeft)
    {
        if (isLeft)
        {
            Debug.Log("penalty left");
            _penaltyRestNumLeft += _penaltyNum;
        }
        else
        {
            Debug.Log("penalty right");
            _penaltyRestNumRight += _penaltyNum;
        }
    }

    int _penaltyRestNumLeft = 0;
    int _penaltyRestNumRight = 0;
}
