using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : Weapon
{
    [SerializeField] private ParticleSystem _particleBullet;
    [SerializeField] private SoundsInWeapon _soundsInWeapon;
    private bool _isCooldDown = false;
    private void Start()
    {
        _soundsInWeapon = GetComponent<SoundsInWeapon>();
    }
    public override void Shoot(GameObject _prefabAmmo, GameObject _placeShoot = null)
    {
       
            if (!_isCooldDown)
            {
                _soundsInWeapon.PlaySound();
                _particleBullet.startSize = 0.5f;
                StartCoroutine(DeleteLineBullet(/*_line*/));
                _isCooldDown = true;
                _particleBullet.Play();
            }
        
    }

   
    IEnumerator DeleteLineBullet(/*GameObject _lineBullet*/)
    {
        yield return new WaitForSeconds(0.25f);
        _soundsInWeapon.StopPlay();
        //   GameObject.Destroy(_lineBullet);
        _particleBullet.Stop();
        _isCooldDown = false;
        yield return null;
    }
    private void OnParticleCollision(GameObject other)
    {
        _particleBullet.startSize = 0;
    }
}
