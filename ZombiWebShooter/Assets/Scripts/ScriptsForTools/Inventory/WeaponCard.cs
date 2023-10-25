using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponCard : MonoBehaviour
{
    [SerializeField] private WeaponMarket _weaponMarket;
    [SerializeField] private int _idWeapon;
    [SerializeField] private int _costWeapon;
    private TextMeshProUGUI _costView;

    private void Start()
    {
        _costView = GetComponentInChildren<TextMeshProUGUI>();
        _costView.text = _costWeapon.ToString();
    }
    public void BuyWeapon()
    {
        _weaponMarket.Buy(_costWeapon, _idWeapon);
       
    }
    public int GetCost()
    {
        return _costWeapon;
    }
}
