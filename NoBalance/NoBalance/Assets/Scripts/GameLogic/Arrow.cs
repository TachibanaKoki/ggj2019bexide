using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public bool _isGround { get; private set; }
    public int _hitPoint { get; private set; } = 1;
    [SerializeField]
    private Text _Text;

    public void SetHitPointText(int hitPoint)
    {
        _hitPoint = hitPoint;
        _Text.enabled = true;
        _Text.text = _HitPointText[_hitPoint - 1]; // メモリ効率のため ToString 避ける。
    }

    private void Start()
    {
        GetComponent<Collider>().enabled = false;
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position,Vector3.down);
        if(Physics.Raycast(ray,1.9f))
        {
            GetComponent<Collider>().enabled = true;
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }

    private static readonly string[] _HitPointText = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
}
