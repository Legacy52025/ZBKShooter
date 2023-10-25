using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Weapon
{
    [SerializeField] ParticleSystem _particleBullet;
    private bool _isCooldDown = false;
    [SerializeField] SoundsInWeapon _soundsInWeapon;
    private void Start()
    {
        _soundsInWeapon = GetComponent<SoundsInWeapon>();
    }
    public override void Shoot(GameObject _prefabAmmo, GameObject _placeShoot)
    {
        
            if (!_isCooldDown)
            {
                _soundsInWeapon.PlaySound();
                _particleBullet.startSize = 1f;
                StartCoroutine(DeleteLineBullet(/*_line*/));
                _isCooldDown = true;
                _particleBullet.Play();
            }
        
    }
    IEnumerator DeleteLineBullet(/*GameObject _lineBullet*/)
    {
        yield return new WaitForSeconds(2.9f);
       
        //   GameObject.Destroy(_lineBullet);
        _particleBullet.Stop();
        _isCooldDown = false;
        yield return null;
    }
    
    private void OnParticleCollision(GameObject other)
    {
       
         //   _particleBullet.startSize = 0;
        

    }
}
