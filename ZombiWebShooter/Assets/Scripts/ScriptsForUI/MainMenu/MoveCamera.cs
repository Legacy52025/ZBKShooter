using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private int _maxMovementRight = 614;
    private int _maxMovementLeft = -250;
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.x > _maxMovementRight || transform.position.x < _maxMovementLeft)
        {
            _speed *= -1;
        }

        transform.position = new Vector3(transform.position.x + _speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
