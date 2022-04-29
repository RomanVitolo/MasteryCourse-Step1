using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class AgentController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 200f;
    Rigidbody2D _rb;
    AgentGrounding _agentGrounding;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _agentGrounding = GetComponent<AgentGrounding>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetInput();
        if (Input.GetButtonDown("Fire1") && _agentGrounding.IsGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce);
        }
        Debug.Log(_agentGrounding.IsGrounded);
    }
    
    void SetInput()
    { 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0);
        //transform.Translate(movement * speed * Time.deltaTime);
        transform.position += movement * speed * Time.deltaTime;
        
        
    }
}
