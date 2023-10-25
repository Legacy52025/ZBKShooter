using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//В классе храним всю информацию о деньгах, заработанных в матче
public class StatsInMatch : MonoBehaviour
{
    [SerializeField] private int _moneyInMatchForZombie = 0; //данные о заработанных деньгах
    [SerializeField] private int _moneyInMatchOther = 0;
    [SerializeField] private int _killedZombie = 0; //данные о убитых зомби
    [SerializeField] private YandexSDK _yandexSDK;

    private void Start()
    {
        _yandexSDK = GameObject.FindGameObjectWithTag("YandexSDK").GetComponent<YandexSDK>();
    }
    public void AddMoney(int _money, bool _gameModeBonus = false)
    {
        if (_gameModeBonus)
        {
           _moneyInMatchOther += _money;
        }
        else
        {
            _moneyInMatchForZombie += _money;
        }
    }
    //TODO: Добавить сохранение на сервер
    public void AddMoneyForEndGame()
    {
        int _moneyAll;
        _yandexSDK.CheckStatusAuth();
        if (_yandexSDK.GetIsAuth())
        {
            _yandexSDK.LoadForMoney();
            _moneyAll = _yandexSDK.GetCoins();
        }
        else
        {
            _moneyAll = PlayerPrefs.GetInt("Money");
        }
        
        if (PlayerPrefs.GetInt("IdGameMode") != 0) 
        {

            
            if (_yandexSDK.GetIsAuth())
            {
                _yandexSDK.SetCoins(_moneyInMatchOther + _moneyInMatchForZombie + _moneyAll);
                _yandexSDK.Save();
            }
            PlayerPrefs.SetInt("Money", _moneyInMatchOther + _moneyInMatchForZombie + _moneyAll);
        }
        else
        {
            
            if (_yandexSDK.GetIsAuth())
            {
                _yandexSDK.SetCoins(_moneyInMatchOther + _moneyAll);
                _yandexSDK.Save();
            }
            PlayerPrefs.SetInt("Money", _moneyInMatchOther + _moneyAll);
        }
    }
    public int GetMoney()
    {
        return _moneyInMatchForZombie;
    }

    public void AddKilledZombie(int _moneyForKilled)
    {
        _killedZombie++;
        AddMoney(_moneyForKilled);
    }


    public int GetKilledZombie()
    {
        return _killedZombie;
    }

}
