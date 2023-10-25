using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamage : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private bool _checkStartCorountine = false;

    private void Start()
    {
        _enemy = gameObject.GetComponent<Enemy>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            _checkStartCorountine = true;
            StartCoroutine(CoroutineGetDamage(collision));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            _checkStartCorountine = false;
            StopCoroutine(CoroutineGetDamage(collision));
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null && !_checkStartCorountine)
        {
            _checkStartCorountine = true;
            StartCoroutine(CoroutineGetDamage(collision));
        }
    }

    IEnumerator CoroutineGetDamage(Collision collision)
    {
            Player _player = collision.gameObject.GetComponent<Player>();
            if (_enemy == null)
            {
            }
            else
            {
                _player.GetDamage(_enemy.SetDamage());
            }
        yield return new WaitForSeconds(0.5f);
    }
}
