using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [field: SerializeField] public bool Passed { get; private set; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var _player = collision.GetComponent<AgentController>();
        if (_player != null)
        {
            Passed = true;
        }
    }
}
