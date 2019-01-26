﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool _isGround { get; private set; }

    private void Update()
    {
        Ray ray = new Ray(transform.position,Vector3.down);
        if(Physics.Raycast(ray,1.1f))
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }
}
