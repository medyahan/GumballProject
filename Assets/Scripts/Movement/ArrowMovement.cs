using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    
    [Header("MOVE")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _movementOffset;
        
    [Header("JUMP")]
    [SerializeField] private float _jumpSpeed;
    
    private float _movementX;
    private float _movementY;
    private float _movementZ;
    
    private void Start()
    {
        
    }
    
    private void Update()
    {
        Move();

        // MOVE CONTROL
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _movementZ = _movementOffset;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _movementZ = -_movementOffset;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _movementX = _movementOffset;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _movementX = -_movementOffset;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            _movementZ = 0;
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _movementX = 0;
        }
        
        // JUMP CONTROL
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        _rb.velocity = new Vector3(_movementX * _moveSpeed * Time.deltaTime, 0, _movementZ * _moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
    }
}
