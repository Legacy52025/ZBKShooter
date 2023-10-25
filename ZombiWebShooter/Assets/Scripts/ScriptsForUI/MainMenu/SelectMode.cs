using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectMode : MonoBehaviour
{
    
    //Тут мы делаем переменные с описанием для всех режимов (подумать над переводом)
    [SerializeField] private string _descriptionGameModeSurvive;
    [SerializeField] private string _descriptionGameModeEscape;
    [SerializeField] private string _descriptionGameModeDestraction;

    [SerializeField] private string _descriptionGameModeSurviveEng;
    [SerializeField] private string _descriptionGameModeEscapeEng;
    [SerializeField] private string _descriptionGameModeDestractionEng;


    //Объект, в который мы записывает описание
    [SerializeField] private TextMeshProUGUI _text;

    //Тут выбранный режим записывается
    [SerializeField] private int _selectedGameMode;

    //В этих трех массивах мы разделяем все сцены по режимам
    [SerializeField] private List<int> _idSceneMapsForGameModeSurvive;
    [SerializeField] private List<int> _idSceneMapsForGameModeEscape;
    [SerializeField] private List<int> _idSceneMapsForGameModeDestraction;

    //Тут находятся все карточки карт
    [SerializeField] private List<GameObject> _panelMapObjects;

    //Тут контент, к которому подцеплять сохжанные карточки
    [SerializeField] private GameObject _listForPanelsMap;

    private List<GameObject> _curretPanelMaps = new List<GameObject>();
    private bool _panelMapsIsSelected = false;

    //создание панелей, в зависимости от выбранного режима
    private void InstantiatePanelMapByGameMode()
    {
        //bool _checkMapsForGameMode = false; //
        for(int i = 0;i<_panelMapObjects.Count;i++)
        {
            switch(_selectedGameMode)
            {
                case 0: 
                    for(int j = 0;j<_idSceneMapsForGameModeSurvive.Count;j++)
                    {
                        if(_panelMapObjects[i].GetComponent<MapsParametrs>().GetIdScene() == _idSceneMapsForGameModeSurvive[j])
                        {
                            GameObject _newPanelMap = Instantiate(_panelMapObjects[i], _listForPanelsMap.transform);
                            Debug.Log("Добавили одну карту");
                            _curretPanelMaps.Add(_newPanelMap);
                        }
                    }
                    break;
                case 1:
                    for (int j = 0; j < _idSceneMapsForGameModeEscape.Count; j++)
                    {
                        if (_panelMapObjects[i].GetComponent<MapsParametrs>().GetIdScene() == _idSceneMapsForGameModeEscape[j])
                        {
                            GameObject _newPanelMap = Instantiate(_panelMapObjects[i], _listForPanelsMap.transform);
                            _curretPanelMaps.Add(_newPanelMap); 
                        }
                    }
                    break;
                case 2:
                    for (int j = 0; j < _idSceneMapsForGameModeDestraction.Count; j++)
                    {
                        if (_panelMapObjects[i].GetComponent<MapsParametrs>().GetIdScene() == _idSceneMapsForGameModeDestraction[j])
                        {
                            GameObject _newPanelMap = Instantiate(_panelMapObjects[i], _listForPanelsMap.transform);
                            _curretPanelMaps.Add(_newPanelMap); 
                        }
                    }
                    break;
            }

            PlayerPrefs.SetInt("IdGameMode", _selectedGameMode);
         /*   if (_checkMapsForGameMove)
            {
                GameObject _newPanelMap = Instantiate(_panelMapObjects[i], _listForPanelsMap.transform);
                _curretPanelMaps.Add(_newPanelMap);
            }*/

           
        }
        if (_curretPanelMaps.Count > 0)
        {
            _panelMapsIsSelected = true;
        }
    }

    private void ClearPanelMaps()
    {
        Debug.Log("Зашли в очистку карточек");
        
        for(int i = 0; i<_curretPanelMaps.Count; i++)
        {
            Destroy(_curretPanelMaps[i]);
        }
        _curretPanelMaps.Clear();
        _panelMapsIsSelected = false;
    }    

    public void SelectGameMode(int _gameMode)
    {
        if(_panelMapsIsSelected)
        {
            ClearPanelMaps();
        }

        _selectedGameMode = _gameMode;
        SelectDescriptionForGameMove();
        InstantiatePanelMapByGameMode();
    }
    private void Update()
    {
        if(_text.text == _descriptionGameModeSurvive || _text.text == _descriptionGameModeSurviveEng)
        {
            if(ClassLanguage.GetCurretLanguage() == Language.rus)
            {
                _text.text = _descriptionGameModeSurvive;
            }
            else
            {
                _text.text = _descriptionGameModeSurviveEng;
            }
        }
        else if(_text.text == _descriptionGameModeEscape || _text.text == _descriptionGameModeEscapeEng)
        {
            if(ClassLanguage.GetCurretLanguage() == Language.rus)
            {
                _text.text = _descriptionGameModeEscape;
            }
            else
            {
                _text.text = _descriptionGameModeEscapeEng;
            }
        }
        else if(_text.text == _descriptionGameModeDestraction || _text.text == _descriptionGameModeDestractionEng)
        {
            if(ClassLanguage.GetCurretLanguage() == Language.rus)
            {
                _text.text = _descriptionGameModeDestraction;
            }
            else
            {
                _text.text = _descriptionGameModeDestractionEng;
            }
        }
    }
    private void SelectDescriptionForGameMove()
    {
        switch(_selectedGameMode)
        {
            case 0: _text.text = _descriptionGameModeSurvive; break;
            case 1: _text.text = _descriptionGameModeEscape; break;
            case 2: _text.text = _descriptionGameModeDestraction; break;
        }
    }
}
