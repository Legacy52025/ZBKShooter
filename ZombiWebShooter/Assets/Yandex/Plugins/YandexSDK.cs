using System.Runtime.InteropServices;
using UnityEngine;
using System;

public class YandexSDK : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void GetPlayerData();

    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void SaveCoins(int _coins);

    [DllImport("__Internal")]
    public static extern void LoadCoins();

    [DllImport("__Internal")]
    public static extern void GetAuthStatus();

    [DllImport("__Internal")]
    public static extern void AddCoinsExtern(int value);

    [DllImport("__Internal")]
    public static extern void ShowADSInGame();

    [DllImport("__Internal")]
    public static extern void ShowADSExternal();

    private string _namePlayer;
    private int _coins;
    private bool _isAuth = false;

    public void ShowADS() //Вызов jslib межстраничной рекламы
    {
        ShowADSExternal();
    }
    public void ShowADSAndRespawn() //Вызов jslib для просмотра рекламы внутри игры
    {
        ShowADSInGame();
    }
    public void RespawnByADS() //Вызывается из jslib, респаунит игрока
    {
        InfoManager _infoManager = GameObject.FindGameObjectWithTag("MainUI").GetComponent<InfoManager>();
        _infoManager.RespawnHeroes();

    }
    public void ShowAddAndGetReward() //Вызов jslib для просмотра рекламы и получения награды
    {
        AddCoinsExtern(500);
    }



    public void AddMoneyForAdd(int value) //Вызывается из jslib, дает деньги игроку
    {
        Money _moneyObject = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Money>();

        _moneyObject.AddMoney(value);

    }    

    public void CheckStatusAuth() //Запускает метод в jslib
    {
        #if !UNITY_EDITOR && UNITY_WEBGL____
        GetAuthStatus();
        #endif
    }

    public void SetNamePlayer(string _name) 
    {
        _namePlayer = _name;
    }
    public bool GetIsAuth() //нужен для получения значения _isAuth
    {
        return _isAuth;
    }
    public void SetStatusAuth(string _status)  //Из jslib берем строку статуса
    {
        if(_status == "lite")
        {
            _isAuth = false;
        }
        {
            _isAuth = true;
        }
        
    }

    public void AuthPlayer() //Запрос на авторизацию
    {
        
        GetPlayerData();
        

    }
    public void SetCoins(int coins) //Из jslib берем коины
    {
        _coins = coins;
    }
    public int GetCoins()
    {
        return _coins;
    }
    public void RateGameByPlayer()  //запрос на оценку игры
    {
        RateGame();
    }
    public void Save() //вызываем jslib метод сохранения
    {
        SaveCoins(_coins);
    }
    public void LoadForMoney() //вызываем jslib метод загрузки
    {
        LoadCoins();
    }
    public void Load(string coins)  //из jslib берем коины
    {
        if (coins == null || coins == "")
        {
            coins = "0";
        }
        _coins = Convert.ToInt32(coins);
    }
    public void Start()
    {
        transform.parent = null;
    }

}
