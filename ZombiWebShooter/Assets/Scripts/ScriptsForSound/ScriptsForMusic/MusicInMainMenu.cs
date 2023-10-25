using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInMainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip[] _mainsTheme;
   [SerializeField] private AudioSource _soundsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        _soundsPlaying = GetComponent<AudioSource>();
        _soundsPlaying.clip = _mainsTheme[0];
        _soundsPlaying.Play();
    }
}
