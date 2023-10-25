using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hpEnemy;
    [SerializeField] private int _moneyForKilled;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _particleBlood;
    [SerializeField] private GameObject _loot;
    [SerializeField] private int _chanceForLoot = 100;
    private StatsInMatch _statsInMatch;
    private bool _isLooted = false;


    private bool _isAlive = true;
    Animator _animatorZombie;

    private void Start()
    {
        _animatorZombie = GetComponent<Animator>();
        _statsInMatch = GameObject.FindGameObjectWithTag("MainUI").GetComponent<StatsInMatch>();
    }

    public bool GetIsAlive()
    {
        return _isAlive;
    }
    public void SetDead()
    {
        if (!_isLooted)
        {
            TryLoot(); 
        }
        _isAlive = false;

        _statsInMatch.AddKilledZombie(_moneyForKilled);
        GetComponent<CapsuleCollider>().enabled = false;
        if (this.GetType() != typeof(ExplZombie) && this.GetType() != typeof(TankZombie))
        {
            _animatorZombie.Play("ZombieDeath");
        }
        else if(this.GetType() == typeof(TankZombie) ) 
        {
           
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int SetDamage()
    {
        return _damage;
    }
    public void GetDamage(float damage)
    {
        StartCoroutine(BloodFromHit());
        if(_hpEnemy-damage > 0)
        {
            _hpEnemy -= (int) damage;
        }
        else
        {
            _hpEnemy = 0;

            
            SetDead();
            
        }
    }
    IEnumerator  BloodFromHit()
    {
        _particleBlood.Play();
        yield return new WaitForSeconds(0.5f);
        _particleBlood.Stop();
        yield return null;
    }
    protected virtual void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Explosion")
        {
            GetDamage(other.GetComponent<ExplDamage>().GetDamage() * 10);
            return;
        }
        else
        {
            Weapon weapon = other.transform.parent.gameObject.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.SetDamage(this);
            }
        }
        
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    
    public void TryLoot()
    {
        _isLooted = true;
        int _randomChance = Random.Range(0, 100);
        if(_randomChance <= _chanceForLoot)
        {
          GameObject _heal = Instantiate(_loot);
          _heal.transform.position = new Vector3( transform.position.x, transform.position.y+1, transform.position.z);
        }
    }

}
