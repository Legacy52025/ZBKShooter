using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private bool _isEndGame = false;
    [SerializeField] private GameObject _menuObject;
    private CheckAndCloseOtherPanels _checkPanel;

    private void Start()
    {
        _checkPanel = GetComponent<CheckAndCloseOtherPanels>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isEndGame)
            {
                OpenMenuInGame();
            }
        }
    }

    public void OpenMenuInGame()
    {
        _checkPanel.CheckAndClosePanels();
        if (_menuObject.activeSelf)
        {
            _menuObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            _menuObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void SetContinueGame()
    {
        _isEndGame = false;
    }
    public void SetGameIsEnd()
    {
        _isEndGame = true;
    }

}
