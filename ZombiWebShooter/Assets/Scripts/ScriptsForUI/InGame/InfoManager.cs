using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpPlayer1Text;
    [SerializeField] private TextMeshProUGUI _hpPlayer2Text;
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private GameObject _diePanel;
    private OpenMenu _openMenu;
    private AudioSource _audioSource;

    private void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("MainPlayer");
        GameObject _finderPlayer2 = GameObject.FindGameObjectWithTag("Player");
        if (_finderPlayer2 != null)
        {
            _player2 = _finderPlayer2;
        }
        else
        {
            _player2 = null;
        }
        _openMenu = GetComponent<OpenMenu>();
    }
    private void Update()
    {
        int _hpHero1 = _player1.GetComponent<Player>().GetCurretHp();
        int _hpHero2;

        if (_player2 != null)
        {
          _hpHero2 = _player2.GetComponent<Player>().GetCurretHp();
        }
        else
        {
            _hpHero2 = 0;
        }
        _hpPlayer1Text.text =Convert.ToString(_hpHero1);
        _hpPlayer2Text.text =Convert.ToString(_hpHero2);

        if(_hpHero1 == 0 || _player1 == null)
        {
            _player1.GetComponent<Player>().SetAlive(false);
            _player1.GetComponent<Player>().HeroDie();
            //Debug.Log("Проверили, что у героя1 0 хп");
        }

        if(_hpHero2 == 0 && _player2!= null)
        {
            _player2.GetComponent<Player>().SetAlive(false);
            _player2.GetComponent<Player>().HeroDie();
            //Debug.Log("Проверили, что у героя2 0 хп");
        }

        if(_hpHero1 == 0 && _hpHero2 == 0)
        {
          //  Debug.Log("Проверили, что у двух героев 0 хп");
            AllHeroesDie();
        }
    }
    
    private void AllHeroesDie()
    {
        Time.timeScale = 0.0f;
        _audioSource.Pause();
        _openMenu.SetGameIsEnd();
        _diePanel.SetActive(true);
    }
   
    [SerializeField] private GameObject _objectButton; 
    public void RespawnHeroes()
    {
       
            //Debug.Log("Должны зареспауниться");
            Time.timeScale = 1.0f;
            _audioSource.Play();
            _openMenu.SetContinueGame();
            if (_player1.GetComponent<Player>() == null)
            {
              //  Debug.Log("Не получается взять скрипт игрока");
            }
            _player1.GetComponent<Player>().HeroRespawn();
            if (_player2 != null)
            {
                _player2.GetComponent<Player>().HeroRespawn();
            }
            _objectButton.SetActive(false);
            _diePanel.SetActive(false);
        
    }

}
