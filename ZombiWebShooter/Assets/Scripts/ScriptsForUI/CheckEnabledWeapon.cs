using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckEnabledWeapon : MonoBehaviour
{
    private Money _money;
    private WeaponCard _weaponCard;
    [SerializeField] private Button _buttonForBuy;

    private void Start()
    {
        _weaponCard = GetComponent<WeaponCard>();
        _money = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Money>();
    }

    private void Update()
    {
        if(_weaponCard.GetCost() > _money.GetMoney() )
        {
            _buttonForBuy.interactable = false;
        }
        else
        {
            _buttonForBuy.interactable = true;
        }
    }
}
