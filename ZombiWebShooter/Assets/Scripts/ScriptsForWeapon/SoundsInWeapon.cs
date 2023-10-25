using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsInWeapon : MonoBehaviour
{
    [SerializeField] private AudioClip _soundShoot;
    private AudioSource _soundSource;
    private void Start()
    {
        _soundSource = GetComponent<AudioSource>();
        _soundSource.clip = _soundShoot;
    }

    public void PlaySound()
    {
       
        _soundSource.Play();
    }

    public void StopPlay()
    {
        _soundSource?.Stop();
    }

}
