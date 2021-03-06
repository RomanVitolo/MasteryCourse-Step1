using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(AgentGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class AgentController : MonoBehaviour, IMove
{
    [field: SerializeField] public float Speed { get; private set; }
    
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private float wallJumpForce = 50f;
    
    Rigidbody2D _rb;
    AgentGrounding _agentGrounding;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _agentGrounding = GetComponent<AgentGrounding>();
    }
    void FixedUpdate()
    {
        SetInput();
    }
    
    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && _agentGrounding.IsGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce);
            
            if (_agentGrounding.groundedDirection != Vector2.down)
            {
                _rb.AddForce(_agentGrounding.groundedDirection * -1 * wallJumpForce);
            }
        }
    }
    
    void SetInput()
    { 
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        Speed = horizontal;
        
        Vector3 movement = new Vector3(horizontal, 0);
        transform.position += movement * movementSpeed * Time.deltaTime;   //transform.Translate(movement * speed * Time.deltaTime);
    }

    public void Bounce()
    {
        _rb.AddForce(Vector2.up * jumpForce);
    }
}
