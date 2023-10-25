using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAllWeapons : MonoBehaviour
{
  [SerializeField] private List<GameObject> _weapon = new List<GameObject>();

    public GameObject GetWeaponObjectById(int _idWeapon)
    {
        if(_weapon[_idWeapon] == null)
        {
            return null;
        }
        return _weapon[_idWeapon];
    }


}
