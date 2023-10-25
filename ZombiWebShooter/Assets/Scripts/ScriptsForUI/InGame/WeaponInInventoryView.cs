using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInInventoryView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _weaponCells = new List<GameObject>();
    [SerializeField] private ListAllWeapons _allWeapons = new ListAllWeapons();
    private Inventory _invetoryWeapon;

    private void Start()
    {
       _invetoryWeapon = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Inventory>();
        SetWeaponInCells();
    }

    private void SetWeaponInCells()
    {
      int[] _weapons = _invetoryWeapon.GetWeaponsInInventory();
      for(int i = 0; i < _weaponCells.Count; i++)
        {
            if(_weapons[i] != 0 && _allWeapons.GetWeaponObjectById(_weapons[i])!=null)
            {
                _weaponCells[i].GetComponent<Image>().sprite = _allWeapons.GetWeaponObjectById(_weapons[i]).GetComponent<Shoot>().GetWeapon().GetImageWeapon();
            }
           
        }    
    }    
}
