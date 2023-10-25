using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon
{
    [SerializeField] private ParticleSystem _particleBullet;
    [SerializeField] private GameObject _grenadeObject;
    [SerializeField] private float _forceGrenade = 5;
    [SerializeField] private SoundsInWeapon _soundsInWeapon;
    private void Start()
    {
        _soundsInWeapon = GetComponent<SoundsInWeapon>();
    }

    private bool _isCooldDown = false;
   //todo: НЕ РАБОТАЕТ - продумать бросок
    public override void Shoot(GameObject _prefabAmmo, GameObject _placeShoot)
    {      
            if (!_isCooldDown)
            {
            _soundsInWeapon.PlaySound();
            GameObject _gren = Instantiate(_grenadeObject);
            _gren.transform.position = transform.position;
            _gren.GetComponent<Rigidbody>().AddForce(_gren.transform.up * _forceGrenade);
            _gren.GetComponentInChildren<ExplosiveGrenade>().Explose();       
            _isCooldDown = true;
            StartCoroutine(CooldownCorountione());
            }
    }

    IEnumerator CooldownCorountione()
    {
        yield return new WaitForSeconds(1.9f);

        _isCooldDown=false;
        yield return null;
    }


    

   
}
