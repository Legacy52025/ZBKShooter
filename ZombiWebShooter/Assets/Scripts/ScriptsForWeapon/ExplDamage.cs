using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 40;
 /*   private void OnParticleCollision(GameObject other)
    {
        if(other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().GetDamage(_damage);
        }
    }*/
 public int GetDamage()
    {
        return _damage;
    }
}
