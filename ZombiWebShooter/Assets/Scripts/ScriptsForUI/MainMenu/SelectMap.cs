using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    [SerializeField] private GameObject _uiChoiceWeapon;
    [SerializeField] private GameObject _uiChoiceMap;
    private BackToMainMenu _backToMainMenu;
    private int _selectedMap;
    private void Start()
    {
        _backToMainMenu = GetComponent<BackToMainMenu>();
    }
    public void SelectMapByID(int _idScene)
    {

        _selectedMap = _idScene;
        _uiChoiceWeapon.SetActive(true);
        _uiChoiceMap.SetActive(false);
    }

    public void CancelSelectMap()
    {
        _uiChoiceMap.SetActive(true);
        _uiChoiceWeapon.SetActive(false);
    }
    
    //TODO: добавить открытие и закрытие вкладки с оружием

    public void LoadLvl()
    {
        GameObject.FindGameObjectWithTag("MainUI").GetComponent<Money>().SaveMoneyInMenu();
        _backToMainMenu.LoadMainMenu(_selectedMap);


    }
}
