using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnTrigger : MonoBehaviour
{
    [SerializeField] private OpenMenu _openMenu;
    [SerializeField] private SwitchUIPanelIngame _panelWin;
    [SerializeField] private StatsInMatch _statsInMatch;
    [SerializeField] private int _moneyForWin;
    private void Start()
    {
        _openMenu = GameObject.FindGameObjectWithTag("MainUI").GetComponent<OpenMenu>();
        _panelWin = GameObject.FindGameObjectWithTag("MainUI").GetComponent<SwitchUIPanelIngame>();
        _statsInMatch = GameObject.FindGameObjectWithTag("MainUI").GetComponent<StatsInMatch>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _openMenu.SetGameIsEnd();
        _panelWin.OpenWinPanel(false);
        _statsInMatch.AddMoney(_moneyForWin, true);
        _statsInMatch.AddMoneyForEndGame();
    }
}
