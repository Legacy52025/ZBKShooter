using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [SerializeField] int[] _idWeaponInInventory = new int[9];
    [SerializeField] private Transform _transformWeaponPlayer1;
    [SerializeField] private Transform _transformWeaponPlayer2;
    private ListAllWeapons _weaponList;
    private int _player1WeaponChoice = 0;
    private int _player2WeaponChoice = 0;


    private GameObject _curretWeaponPlayer1 = null;
    private GameObject _curretWeaponPlayer2 = null;
    private bool _isGame = true;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _isGame = false;
            SaveInventoryBetweenScenes.ClearInventory();
        }
        else
        {
            _weaponList = GetComponent<ListAllWeapons>();
            _idWeaponInInventory = SaveInventoryBetweenScenes.GetWeaponBetweenScenes();
            _player1WeaponChoice = 0;
            SwapWeapon(1, 0);
            if (PlayerPrefs.GetInt("NumberPlayers") == 2)
            {
                _player2WeaponChoice = 0;
                SwapWeapon(2, 0);
            }
        }
    }
   
    private void Update()
    {
        if(_isGame)
        {
            CheckSwitchWeaponPlayer1();

            if (PlayerPrefs.GetInt("NumberPlayers") == 2)
            { 
                CheckSwitchWeaponPlayer2(); 
            }
        }
    }
    private void CheckSwitchWeaponPlayer1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(1, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapWeapon(1, 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwapWeapon(1, 3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwapWeapon(1, 4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SwapWeapon(1, 5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SwapWeapon(1, 6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SwapWeapon(1, 7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SwapWeapon(1, 8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SwapWeapon(1, 9);
        }
    }
    private void CheckSwitchWeaponPlayer2()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwapWeapon(2, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            SwapWeapon(2, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SwapWeapon(2, 2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SwapWeapon(2, 3);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            SwapWeapon(2, 4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            SwapWeapon(2, 5);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            SwapWeapon(2, 6);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            SwapWeapon(2, 7);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            SwapWeapon(2, 8);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            SwapWeapon(2, 9);
        }
    }
    public int[] GetWeaponsInInventory()
    {
        return _idWeaponInInventory;
    }


    private void SwapWeapon(int _numberPlayer, int _index)
    {
        if (_numberPlayer == 1)
        {
            if (_idWeaponInInventory[_index] != 0)
            {
                if (_curretWeaponPlayer1 != null)
                {
                Destroy(_curretWeaponPlayer1);
                }
            
               

                _curretWeaponPlayer1 = Instantiate(_weaponList.GetWeaponObjectById(_idWeaponInInventory[_index]), _transformWeaponPlayer1);
            }
        }
        else
        {
            if (_idWeaponInInventory[_index] != 0)
            {
                if (_curretWeaponPlayer2 != null)
                {
                    Destroy(_curretWeaponPlayer2);
                }
                _curretWeaponPlayer2 = Instantiate(_weaponList.GetWeaponObjectById(_idWeaponInInventory[_index]), _transformWeaponPlayer2);
            }
        }
        
    }
    public void SaveItemInInInventoryBetweenScene()
    {
        SaveInventoryBetweenScenes.SetWeaponToInventory(_idWeaponInInventory);
    }

    public void SetWeaponInSlot(int _idSlot, int _idWeapon)
    {
        if(_idSlot < 10)
        {
            _idWeaponInInventory[_idSlot] = _idWeapon;
            SaveItemInInInventoryBetweenScene();
        }
    }
    public void ClearAllItemInInventory()
    {
        for(int i = 1;i< _idWeaponInInventory.Length;i++)
        {
            _idWeaponInInventory[i] = 0;
        }
    }



}
