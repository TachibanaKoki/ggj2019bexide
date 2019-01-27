using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverCollider : MonoBehaviour
{
    public static Action<bool> GameOverEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arrow")
        {
            GameOverEvent?.Invoke(false);
        }
    }
}
