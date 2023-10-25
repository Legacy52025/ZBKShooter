using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplZombie : Enemy
{
   [SerializeField] ParticleSystem _particleForBoom;
   public void Boom()
    {
        StartCoroutine(CorountineBoom());
    }
    public void CreateParticleBoom()
    {
        ParticleSystem _boom = Instantiate(_particleForBoom, gameObject.transform.position, new Quaternion());
        _boom.Play();
        StartCoroutine(StopBoom(_boom));
    }
    IEnumerator StopBoom(ParticleSystem _boom)
    {
        yield return new WaitForSeconds(0.9f);
        _boom.Stop();
        Destroy(_boom);
        yield return null;
    }
    IEnumerator CorountineBoom()
    {
        yield return new WaitForSeconds(2.0f); //Переделать так, чтобы партикловая система создавалась в глобальных координатах
        CreateParticleBoom();
        Debug.Log("Boom");
        yield return null;
        
            SetDead();
        
    }
}
