using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFlipped : MonoBehaviour
{
    [SerializeField] private float shellSpeed = 5f;
    
    Rigidbody2D _rb;
    Collider2D _collider;

    private Vector2 direction;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(direction.x * shellSpeed, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.WasHitByPlayer())
        {
            HandlePlayerCollision(other);
        }
        else
        {
            if (other.WasSide())
            {
                LaunchShell(other);
                var takeShellHits = other.collider.GetComponent<ITakeShellHits>();
                if (takeShellHits != null)
                {
                    takeShellHits.HandleShellHit(this);
                }
            }
        }
    }

    private void HandlePlayerCollision(Collision2D other)
    {
        var _agentController = other.collider.GetComponent<AgentController>();
        if (direction.magnitude == 0)
        {
            LaunchShell(other);
            if (other.WasHitFromTopSide())
            {
                _agentController.Bounce();
            }
        }
        else
        {
            if (other.WasHitFromTopSide())
            {
                direction = Vector2.zero;
                _agentController.Bounce();
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void LaunchShell(Collision2D other)
    {
        var floatDirection = other.contacts[0].normal.x > 0 ? 1f : -1f;
        direction = new Vector2(floatDirection, 0);
    }
}
