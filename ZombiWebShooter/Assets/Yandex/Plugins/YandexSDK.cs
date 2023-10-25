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

    public void ShowADS() //����� jslib ������������� �������
    {
        ShowADSExternal();
    }
    public void ShowADSAndRespawn() //����� jslib ��� ��������� ������� ������ ����
    {
        ShowADSInGame();
    }
    public void RespawnByADS() //���������� �� jslib, ��������� ������
    {
        InfoManager _infoManager = GameObject.FindGameObjectWithTag("MainUI").GetComponent<InfoManager>();
        _infoManager.RespawnHeroes();

    }
    public void ShowAddAndGetReward() //����� jslib ��� ��������� ������� � ��������� �������
    {
        AddCoinsExtern(500);
    }



    public void AddMoneyForAdd(int value) //���������� �� jslib, ���� ������ ������
    {
        Money _moneyObject = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Money>();

        _moneyObject.AddMoney(value);

    }    

    public void CheckStatusAuth() //��������� ����� � jslib
    {
        #if !UNITY_EDITOR && UNITY_WEBGL____
        GetAuthStatus();
        #endif
    }

    public void SetNamePlayer(string _name) 
    {
        _namePlayer = _name;
    }
    public bool GetIsAuth() //����� ��� ��������� �������� _isAuth
    {
        return _isAuth;
    }
    public void SetStatusAuth(string _status)  //�� jslib ����� ������ �������
    {
        if(_status == "lite")
        {
            _isAuth = false;
        }
        {
            _isAuth = true;
        }
        
    }

    public void AuthPlayer() //������ �� �����������
    {
        
        GetPlayerData();
        

    }
    public void SetCoins(int coins) //�� jslib ����� �����
    {
        _coins = coins;
    }
    public int GetCoins()
    {
        return _coins;
    }
    public void RateGameByPlayer()  //������ �� ������ ����
    {
        RateGame();
    }
    public void Save() //�������� jslib ����� ����������
    {
        SaveCoins(_coins);
    }
    public void LoadForMoney() //�������� jslib ����� ��������
    {
        LoadCoins();
    }
    public void Load(string coins)  //�� jslib ����� �����
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
