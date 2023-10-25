using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Transform _cameraTransform;

    public void Start()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    public void Update()
    {
       _cameraTransform.position = new Vector3( _playerTransform.position.x, _playerTransform.position.y+10, _playerTransform.position.z-7);
    }


}
