using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed = 30f;
    private Rigidbody _rbHero;
    private CharacterController _characterController;

    private void Start()
    {
       _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveLogic();
    }
    public void StopMove()
    {
        _horizontal = 0;
        _vertical = 0;
    }
    private float _horizontal = 0;
    private float _vertical = 0;
    public void MoveLogic()
    {
        Vector3 _moveInput = new Vector3(_horizontal * Time.deltaTime * _speed, 0, _vertical * Time.deltaTime * _speed);
        _characterController.Move(_moveInput);
        if (_moveInput.magnitude > 0.01f)
        {
            // Quaternion _curretRotation = transform.rotation;
            Quaternion _targetRotation = Quaternion.LookRotation(_moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _rotationSpeed);
        }
        if (gameObject.tag == "MainPlayer")
        {
            if (Input.GetKey(KeyCode.W))
            {
                _vertical = 1;
            }
            if(Input.GetKey(KeyCode.S))
            {
                _vertical = -1;
            }
            if (Input.GetKey(KeyCode.A)) 
            {
                _horizontal = -1;
            }
            if(Input.GetKey(KeyCode.D))
            {
                _horizontal = 1;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _vertical = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                _vertical = -1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _horizontal = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _horizontal = 1;
            }
        }

        if (gameObject.tag == "MainPlayer")
        {
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                _vertical = 0;
                          }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                _horizontal = 0;
                           }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                _vertical = 0;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                _horizontal = 0;
            }
        }
        
    }

}
