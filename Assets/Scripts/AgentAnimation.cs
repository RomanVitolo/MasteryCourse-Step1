using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class AgentAnimation : MonoBehaviour
{
    Animator _animator;
    IMove _move;
    SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponent<IMove>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float speed = _move.Speed;
        _animator.SetFloat("Speed", Mathf.Abs(speed));
        Debug.Log(speed);
        if (speed != 0)
        {
            _spriteRenderer.flipX = speed > 0;
        }
        
    }
}
