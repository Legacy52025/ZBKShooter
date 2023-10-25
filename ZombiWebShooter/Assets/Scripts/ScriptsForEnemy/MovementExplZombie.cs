using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementExplZombie : MovementEnemyes
{
    private bool _isStartExpl = false;
    protected override void Movement()
    {
        if (_player2 != null)
        {
            if ((Vector3.Distance(transform.position, _player1.transform.position) < Vector3.Distance(transform.position, _player2.transform.position) && _player1.GetComponent<Player>().GetAlive()))
            {
                _goal = _player1.transform;
            }
            else
            {
                _goal = _player2.transform;
            }
        }
        if(Vector3.Distance(transform.position, _goal.position) < 5)
        {
            _isStartExpl = true;
        }
        if (GetComponent<Enemy>().GetIsAlive())
        {
            //нарисовать луч до игрока, если луч дошел без препятствий, взрыв
            if (_isStartExpl)
            {
                GetComponent<ExplZombie>().Boom();
            }
            else
            {
                _agent.destination = _goal.position;
            }
        }
    }
    private void Start()
    {
        GetInfoForStart();
    }
}
