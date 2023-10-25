using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _curretHPhero = 100;
    [SerializeField] private int _maxHPhero = 100;
    [SerializeField] private Transform _respawnTransform;
    private bool _isAlive = true;   

    public int GetCurretHp()
    {
        return _curretHPhero;
    }

    public void GetDamage(int _damage)
    {
        if(_curretHPhero - _damage > 0)
        {
            _curretHPhero -= _damage;
        }
        else
        {
            _curretHPhero = 0;
            //описать смерть - сделано в InfoManager
        }
    }
    public void SetAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }
    public bool GetAlive()
    {
        return _isAlive;
    }
    public void HeroDie()
    {
        gameObject.SetActive(false);
    }
    public void HeroRespawn()
    {

        gameObject.SetActive(true);
        GetComponent<MovementHero>().StopMove();// протестировать
        SetAlive(true);
        _curretHPhero = _maxHPhero;
        gameObject.transform.position = _respawnTransform.position;
    }
    public void GetHeal(int _heal)
    {
        if(_curretHPhero + _heal <= _maxHPhero)
        {
            _curretHPhero += _heal;
        }
        else
        {
            _curretHPhero = _maxHPhero;
        }
    }
   
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Explosion")
        {

            GetDamage(other.GetComponent<ExplDamage>().GetDamage());
        }    
        else if(other.GetComponentInParent<Enemy>() != null)
        {
            GetDamage(other.GetComponentInParent<Enemy>().SetDamage());
        }
    }


}
