using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private GameObject spawnOnStompPrefab;

    Rigidbody2D _rb;
    Collider2D _collider;
    SpriteRenderer _spriteRenderer;
    
    private Vector2 direction = Vector2.left;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEdge() || HitNotPlayer())
        {
            SwitchDirections();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.WasHitByPlayer())
        {
            if (other.WasHitFromTopSide())
            {
                HandleWalkerStomped(other.collider.GetComponent<AgentController>());
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
        
    }

    private void HandleWalkerStomped(AgentController agentController)
    {
        if (spawnOnStompPrefab != null)
        {
            Instantiate(spawnOnStompPrefab, transform.position, transform.rotation);
        }
        agentController.Bounce();
        
        Destroy(gameObject);
    }


    private bool HitNotPlayer()
    {
        float x = GetFowardX();
        float y = transform.position.y;
        
        Vector2 origin = new Vector2(x, y);
        
        Debug.DrawRay(origin, direction * 0.1f);
        var hit = Physics2D.Raycast(origin, direction, 0.1f);

        if (hit.collider == null || 
            hit.collider.isTrigger || 
            hit.collider.GetComponent<AgentController>() != null)
        {
            return false;
        }
        return true;
    }

    
    

    private bool ReachedEdge()
    {
        float x = GetFowardX();
        float y = _collider.bounds.min.y;
        
        Vector2 origin = new Vector2(x, y);
        
        Debug.DrawRay(origin, Vector2.down * 0.1f);

        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        if (hit.collider == null)
        {
            return true;
        }
        return false;
    }

    private float GetFowardX()
    {
        return direction.x == -1 ? _collider.bounds.min.x - 0.1f : _collider.bounds.max.x + 0.1f;
    }

    private void SwitchDirections()
    {
        direction *= -1;
        _spriteRenderer.flipX = !_spriteRenderer.flipX; //Hace lo opuesto con el "!" que le otorgamos
    }
}
