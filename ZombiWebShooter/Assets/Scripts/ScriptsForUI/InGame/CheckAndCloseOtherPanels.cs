using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAndCloseOtherPanels : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panelObjects ;

    public void CheckAndClosePanels()
    {
        foreach(GameObject _panel in _panelObjects)
        {
            if(_panel.activeSelf)
            {
                _panel.SetActive(false);
            }    
        }
    }

}
