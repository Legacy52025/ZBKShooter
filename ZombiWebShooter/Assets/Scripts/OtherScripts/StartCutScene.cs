using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    [SerializeField] private GameObject _mainUi;
    [SerializeField] private GameObject _objectOfCameras;
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private List<GameObject> _destroyComponentsCutScene;
    [SerializeField] private StatsInMatch _statsInMatch;
    [SerializeField] private OpenMenu _openMenu;

    private Animator _animator;

    private void Start()
    {
        _mainUi = GameObject.FindGameObjectWithTag("MainUI");
        _animator = GetComponent<Animator>();
        _animator.Play("IdleOfBridge");
        _statsInMatch = _mainUi.GetComponent<StatsInMatch>();
        _openMenu = _mainUi.GetComponent<OpenMenu>();
    }
    public void DestroyCutScneneObjects()
    {
        for (int i = 0; i < _destroyComponentsCutScene.Count; i++)
        {
            Destroy(_destroyComponentsCutScene[i]);
        }
    }

    public void StartCutScenes()
    {
        Debug.Log("Кат сцена началась");
        _objectOfCameras.GetComponent<ChangeCameras>().SwitchCamerasToScene();
        _mainUi.GetComponent<SwitchUIPanelIngame>().OpenWinPanel();
        _statsInMatch.AddMoney(1000, true);
        _statsInMatch.AddMoneyForEndGame();
        _openMenu.SetGameIsEnd();
        _player1.SetActive(false);
        _player2.SetActive(false);
        _animator.Play("EndOfBridge");
    }
}
