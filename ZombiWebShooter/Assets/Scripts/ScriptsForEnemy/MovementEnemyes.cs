using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementEnemyes : MonoBehaviour
{
    protected GameObject _player1;
    protected GameObject _player2;

    protected Transform _goal;
    protected NavMeshAgent _agent;
    protected bool _isDestruction = false;
    protected int _distanceForAngry = 0;

    // Start is called before the first frame update
    private void Start()
    {
       GetInfoForStart();
    }
    protected void GetInfoForStart()
    {
        _player1 = GameObject.FindGameObjectWithTag("MainPlayer");
        _player2 = GameObject.FindGameObjectWithTag("Player");
        _goal = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
        if (PlayerPrefs.GetInt("IdGameMode") == 2)
        {
            _isDestruction = true;
            if (GetComponent<TankZombie>() != null)
            {
                _distanceForAngry = 50;
            }
            else if(GetComponent<FastZombie>() != null)
            {
                _distanceForAngry = 40;
            }
            else
            {
                _distanceForAngry = 30;
            }
        }
    }

    private void Update()
    {
        Movement();
    }
    protected virtual void Movement()
    {
        if (_player2 != null)
        {
            if (_isDestruction)
            {
                if (Vector3.Distance(transform.position, _player1.transform.position) < _distanceForAngry && Vector3.Distance(transform.position, _player2.transform.position) < _distanceForAngry)
                {
                    if ((Vector3.Distance(transform.position, _player1.transform.position) < Vector3.Distance(transform.position, _player2.transform.position))
                        && _player1.GetComponent<Player>().GetAlive())
                    {
                        _goal = _player1.transform;
                    }
                    else
                    {
                        _goal = _player2.transform;
                    }
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, _player1.transform.position) < Vector3.Distance(transform.position, _player2.transform.position))
                {
                    _goal = _player1.transform;
                }
                else
                {
                    _goal = _player2.transform;
                }
            }
        }

        if (GetComponent<Enemy>().GetIsAlive())
        {
            if (!_isDestruction)
            {
                _agent.destination = _goal.position;
            }
            else
            {
                if (Vector3.Distance(transform.position, _player1.transform.position) < _distanceForAngry)
                {
                    _agent.destination = _goal.position;
                }
                else
                {
                    _agent.destination = transform.position;
                }
            }
        }
    }
}
