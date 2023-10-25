using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class MapsParametrs : MonoBehaviour
{
    [SerializeField] private SelectMap _selectMap;
    [SerializeField] Sprite _iconMap;
    [SerializeField] private int _idScene;

    [SerializeField] Image _imageMap;

    private void Start()
    {
        _imageMap.sprite = _iconMap;
    }

    public int GetIdScene()
    {
        return _idScene;
    }

    public void ChoiceMap()
    {
        GameObject.FindGameObjectWithTag("MainUI").GetComponent<SelectMap>().SelectMapByID(_idScene);
    }

}
