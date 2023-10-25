using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TankZombie : Enemy
{
    [SerializeField] private NavMeshAgent _curretNavMesh;
    [SerializeField] private float _curretSpeedTank;
    [SerializeField] private float _curretSpeedAngularTank;

    [SerializeField] private float _koefSpeedChase = 2;
    [SerializeField] private float _koefSpeedAngleChase = 2.0f;


    [SerializeField] private bool _isCooldown = false;
    [SerializeField] private float _coolDownSec = 5.0f;
    [SerializeField] private float _chaseTime = 3.0f;

    [SerializeField] private float _curretCoolDown;
    [SerializeField] private float _curretChaseTime;

    [SerializeField] private ParticleSystem _particleChase;

    private void Start()
    {
        _curretNavMesh = GetComponent<NavMeshAgent>();
        _curretSpeedTank = _curretNavMesh.speed;
        _curretSpeedAngularTank = _curretNavMesh.angularSpeed;

        _curretChaseTime = _chaseTime;
    }
    private void Update()
    {
        if(_isCooldown)
        {
            _curretCoolDown -= Time.deltaTime;
            if(_curretCoolDown <= 0)
            {
                _isCooldown = false;
                _curretChaseTime = _chaseTime;
            }
        }
        else
        {
            if(_curretChaseTime == _chaseTime)
            {
                Chase();
            }
            _curretChaseTime -= Time.deltaTime;
            if(_curretChaseTime <= 0)
            {
                _isCooldown = true;
                _curretCoolDown = _coolDownSec;
                StopChase();
            }
        }
    }

    private void Chase()
    {
        _particleChase.Play();
        _curretNavMesh.speed = _curretSpeedTank * _koefSpeedChase;
        _curretNavMesh.angularSpeed = _curretSpeedAngularTank * _koefSpeedAngleChase;
    }

    private void StopChase()
    {
        _particleChase.Stop();
        _curretNavMesh.speed = _curretSpeedTank;
        _curretNavMesh.angularSpeed = _curretSpeedAngularTank;
    }




}
