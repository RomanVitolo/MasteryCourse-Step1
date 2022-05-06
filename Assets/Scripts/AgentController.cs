using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class AgentController : MonoBehaviour, IMove
{
    [field: SerializeField] public float Speed { get; private set; }
    
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private float jumpForce = 200f;
    
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
        if (Input.GetButtonDown("Jump") && _agentGrounding.IsGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce);
        }
    }
    
    void SetInput()
    { 
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;
        
        Vector3 movement = new Vector3(horizontal, 0);
        transform.position += movement * movementSpeed * Time.deltaTime;   //transform.Translate(movement * speed * Time.deltaTime);
    }
}
