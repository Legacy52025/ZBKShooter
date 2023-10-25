using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    [SerializeField] private int _moneyPlayer;
    [SerializeField] private YandexSDK _yandexSDK;
    

    private void Start()
    {
        _yandexSDK = GameObject.FindGameObjectWithTag("YandexSDK").GetComponent<YandexSDK>();
        //TODO: �������� ��������. ���� ���� ����������� � ����, �� ��������� ������ � �������
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
          //  _yandexSDK.AuthPlayer(); �� ���� �� �����, �.�. ����������� ������������� ��� ������ � ����
          //������ ������. �����, ���� �������������, ����� ������ �� �������, ����� � ����������
            _yandexSDK.CheckStatusAuth();
            if(_yandexSDK.GetIsAuth())
            {
                _yandexSDK.LoadForMoney();
                _moneyPlayer = _yandexSDK.GetCoins();
            }
            else
            {
                _moneyPlayer = PlayerPrefs.GetInt("Money");
            }
        }
    }
    public bool GetMoneyForBuy(int _cost)
    {
        if(_moneyPlayer - _cost > 0)
        {
            _moneyPlayer -= _cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetMoney()
    {
        return _moneyPlayer;
    }
    public void SaveMoneyInMenu()
    {
        //��������� ������ �� �������. ���������, ��� ������������ �������������, ���� ��, ��������� �� ������
        PlayerPrefs.SetInt("Money", GetMoney());
        _yandexSDK.CheckStatusAuth();
        if (_yandexSDK.GetIsAuth())
        {
            _yandexSDK.SetCoins(GetMoney());
            _yandexSDK.Save();
        }
    }
    public void AddMoney(int _money)
    {
        _moneyPlayer += _money;
        PlayerPrefs.SetInt("Money", _moneyPlayer);
        if (_yandexSDK.GetIsAuth())
        {
            _yandexSDK.SetCoins(GetMoney());
            _yandexSDK.Save();
        }
    }
 

}
