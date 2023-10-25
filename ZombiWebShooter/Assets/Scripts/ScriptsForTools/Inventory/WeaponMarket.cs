using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//В этом классе обрабатываем покупки
public class WeaponMarket : MonoBehaviour
{
    
    [SerializeField] private Money _moneyPlayer;
    [SerializeField] private Inventory _inventoryPlayer;

    private void Start()
    {
      //   _moneyPlayer = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Money>();
    }

    public bool Buy(int _price, int _idWeapon)
    {
        if(_moneyPlayer.GetMoneyForBuy(_price))
        {
            _inventoryPlayer.SetWeaponInSlot(_idWeapon-1, _idWeapon);
            Debug.Log("Успешно купили");
            return true;
        }
        else
        {
            Debug.Log("Ошибка при покупке");
            return false;
        }
    }


}
