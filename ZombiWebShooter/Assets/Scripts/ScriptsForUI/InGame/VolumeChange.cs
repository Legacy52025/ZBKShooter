using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource _audioSource;
    private GlobalSoundSetting _soundSetting;
   [SerializeField] private float _volume;
    private float _koefSound = 1.0f;

    private void Start()
    {
        if(GetComponent<Enemy>()!= null)
        {
            _koefSound = 100.0f;
        }
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _audioSource.volume * PlayerPrefs.GetFloat("Sound");
        _soundSetting = GameObject.FindGameObjectWithTag("MainUI").GetComponent<GlobalSoundSetting>();
        _volume = _audioSource.volume;
    }

    private void Update()
    {
    //    if(_soundSetting.GetChangeSoundParammetr())
     //   {
            _audioSource.volume = /*_volume */ PlayerPrefs.GetFloat("Sound") / _koefSound;
      //  }
    }

}
