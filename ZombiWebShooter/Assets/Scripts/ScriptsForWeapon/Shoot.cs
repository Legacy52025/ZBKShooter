using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shootForce;
    [SerializeField] private GameObject _spawnTransformBullet;
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private Weapon _weapon;
    private bool _isMainPlayer = true;
    private void Start()
    {
        if (_weapon == null)
        {
            _weapon = GetComponentInChildren<Weapon>();
        }
       
        if (transform.parent.parent.tag != "MainPlayer")
        {
            _isMainPlayer = false;
            Debug.Log("ƒва игрока");
        }
    }
    private void Update()
    {
        
        if (_weapon != null)
        {
            if (_isMainPlayer)
            {

                if (Input.GetKeyUp(KeyCode.Space) )
                {
                 _weapon.Shoot(null, null);
                }
                if((Input.GetKey(KeyCode.Space)) && (_weapon.GetType() == typeof(Ak47) || _weapon.GetType() == typeof(Minigun) || _weapon.GetType() == typeof(Uzi) ) )
                {
                    _weapon.Shoot(null, null);
                }
            }
            else
            {
              
                if (Input.GetKeyUp(KeyCode.KeypadEnter) && _weapon.GetType() != typeof(Ak47))
                {
                    Debug.Log("—юда попадаем2");
                    _weapon.Shoot(null, null);
                }
                if (Input.GetKey(KeyCode.KeypadEnter) /*&& _weapon.GetType() == typeof(Ak47)*/)
                {
                    Debug.Log("—юда попадаем3");
                    _weapon.Shoot(null, null);
                }
            }
        }
    }

   
    IEnumerator BulletFly(GameObject _gameobject)
    {
        yield return new WaitForSeconds(1.0f);
        GameObject.Destroy(_gameobject);
        yield return null;
    }
    public Weapon GetWeapon()
    {
        return _weapon;
    }
}
