using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUIPanelIngame : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPanelHero1;
    [SerializeField] private GameObject _weaponPanelHero2;
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private GameObject _winPanel;

    public void OpenWinPanel(bool _isCutScene = true)
    {
        if (!_isCutScene)
        {
            Time.timeScale = 0.0f;
        }
        _weaponPanelHero1.SetActive(false);
        _weaponPanelHero2.SetActive(false);
        _winPanel.SetActive(true);
    }

    public void OpenDeathPanel()
    {
        _weaponPanelHero1.SetActive(false);
        _weaponPanelHero2.SetActive(false);
        _deathPanel.SetActive(true);
    }
}
