using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADSInMainMenuController : MonoBehaviour
{
    private int _coolDown = 0;
    [SerializeField] private Button _ADSButton;
    [SerializeField] private GameObject _objectNotification;

    private void Start()
    {
        _coolDown = PlayerPrefs.GetInt("CoolDownADS");

        if(_coolDown <= 0)
        {
            _ADSButton.enabled = true;
            _objectNotification.SetActive(true);
        }
        else
        {
            _ADSButton.enabled = false;
            _objectNotification.SetActive(false);
        }
    }
    public void SetCooldown()
    {
        _coolDown = 5;
        PlayerPrefs.SetInt("CoolDownADS", _coolDown);
        _ADSButton.enabled = false;
        _objectNotification.SetActive(false);
    }
    public void LoadMap()
    {
        _coolDown--;
        if (_coolDown <= 0)
        { 
            _coolDown = 0;
        }
        if(_coolDown == 5)
        {
           ShowADS();
        }

        PlayerPrefs.SetInt("CoolDownADS", _coolDown  );
    }
    private void ShowADS()
    {
        GameObject.FindGameObjectWithTag("YandexSDK").GetComponent<YandexSDK>().ShowADS();
    }
    public int GetCoolDown()
    {
        return _coolDown;
    }
}
