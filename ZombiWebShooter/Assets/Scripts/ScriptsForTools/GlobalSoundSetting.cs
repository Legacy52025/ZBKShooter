using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSoundSetting : MonoBehaviour
{
    [SerializeField] private float _soundSetting = 1.0f;
    [SerializeField] private float _musicSetting = 1.0f;

    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSound;

    private AudioSource _audioSource;
   // private bool _isMainMenu;
    private bool _isChangeSound = false;

    private void Start()
    {
        _soundSetting = PlayerPrefs.GetFloat("Sound");
        _musicSetting = PlayerPrefs.GetFloat("Music");

        _audioSource = GetComponent<AudioSource>();

        _sliderMusic.value = _musicSetting;
        _sliderSound.value = _soundSetting;  
    }
    private void Update()
    {
        _audioSource.volume = _musicSetting;
    }
    public void SaveSoundMusicSetting()
    {
        PlayerPrefs.SetFloat("Sound", _soundSetting);
        PlayerPrefs.SetFloat("Music", _musicSetting);
    }
    public void ChangeSoundSetting(float _newSetting)
    {
        _soundSetting = _newSetting;
        _isChangeSound = true;
        StartCoroutine(ChangeSoundParametrBack());
        SaveSoundMusicSetting();
    }

    IEnumerator ChangeSoundParametrBack()
    {
        yield return new WaitForSeconds(1.0f);
        _isChangeSound = false;
        yield return null;
    }
    public bool GetChangeSoundParammetr()
    {
        return _isChangeSound;
    }
    public void ChangeMusicSetting(float _newSetting)
    {
        _musicSetting = _newSetting;
        SaveSoundMusicSetting();
    }

    public float SetMusicSetting(float _curretSetting)
    {
        return _musicSetting * _curretSetting;
    }

    public float SetSoundSetting(float _curretSetting)
    {
        return _soundSetting * _curretSetting;
    }

    
}
