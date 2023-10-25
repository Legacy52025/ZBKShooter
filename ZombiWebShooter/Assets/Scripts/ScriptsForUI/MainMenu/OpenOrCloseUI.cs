using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOrCloseUI : MonoBehaviour
{
    [SerializeField] private GameObject _uiObject;

    public void OpenOrClose()
    {
        Debug.Log("Отрабоотало");
        if(_uiObject.activeSelf)
        {
            _uiObject.SetActive(false);
        }
        else
        {
            _uiObject.SetActive(true);  
        }
    }

}
