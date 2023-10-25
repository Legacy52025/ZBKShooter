using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveGrenade : MonoBehaviour
{
    [SerializeField] private GameObject _particleExplosive;
    [SerializeField] private SoundsInWeapon _soundsInWeapon;
    private void Start()
    {
        _soundsInWeapon = GetComponent<SoundsInWeapon>();
    }
    public void Explose()
    {
        StartCoroutine(CorountineTimerAndExplose());
    }

        
    IEnumerator CorountineTimerAndExplose()
    {
        yield return new WaitForSeconds(1.9f);
        GameObject _particleExpl = Instantiate(_particleExplosive);
        _particleExpl.transform.position = transform.position;
        _particleExpl.GetComponent<ParticleSystem>().Play();
        _soundsInWeapon.PlaySound();
        yield return new WaitForSeconds(0.9f);
        _particleExpl.GetComponent<ParticleSystem>().Stop();
        Debug.Log("Тут должен уничтожиться");
        Destroy(_particleExpl);
        Destroy(gameObject);
        yield return null;  
    }
  

}
