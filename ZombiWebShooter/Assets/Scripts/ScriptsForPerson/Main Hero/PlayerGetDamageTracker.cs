using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamageTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _player = gameObject.GetComponent<Player>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CoroutineGetDamage(collision));
    }

    private void OnCollisionExit(Collision collision)
    {
        StopCoroutine(CoroutineGetDamage(collision));
    }

    IEnumerator  CoroutineGetDamage(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
            if (_enemy == null)
            {
            }
            else
            {
                _player.GetDamage(_enemy.SetDamage());
            }
        }
        yield return new WaitForSeconds(0.5f);
    }



}
