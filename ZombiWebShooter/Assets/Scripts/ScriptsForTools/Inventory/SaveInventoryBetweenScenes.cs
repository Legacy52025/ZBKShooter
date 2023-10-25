using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveInventoryBetweenScenes 
{
    private static int[] _listOfInventory = new int[9];

    public static int[] GetWeaponBetweenScenes()
    {
        _listOfInventory[0] = 1;
        return _listOfInventory;
    }
    public static void ClearInventory()
    {
        _listOfInventory = new int[9];
    }
    public static void SetWeaponToInventory(int[] _weapons)
    {
        _listOfInventory = _weapons;
        _listOfInventory[0] = 1;
    }


}
