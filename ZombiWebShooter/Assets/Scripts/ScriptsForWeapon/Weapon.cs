using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected GameObject _prefabAmmo = null;
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private int _damageWeapon = 10;
    public Sprite GetImageWeapon()
    {
        return _weaponSprite;
    }
    public virtual void Shoot(GameObject _objAmmo = null, GameObject _placeShoot = null)
    {

    }
    public virtual void SetDamage(Enemy _enemy)
    {
        if (_enemy != null)
        {
            _enemy.GetDamage(_damageWeapon);
        }
    }

}
