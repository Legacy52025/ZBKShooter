using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedParticleSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void PlayParticSystem()
    {
        _particleSystem.Play();
    }




}
