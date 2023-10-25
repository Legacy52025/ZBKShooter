using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCameraController : MonoBehaviour
{
    [SerializeField] private GameObject _cameraPlayerOne;
    [SerializeField] private GameObject _cameraPlayerTwo;
    [SerializeField] private GameObject _player2;
    [SerializeField] private GameObject _panelWeaponForPlayer2;

    private void Start()
    {
        if(PlayerPrefs.GetInt("NumberPlayers") == 2) //Тут проверка на наличие игрока 2
        {
            _cameraPlayerOne.GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
            _player2.SetActive(true);
            _panelWeaponForPlayer2.SetActive(true);
        }
        else
        {
            _cameraPlayerTwo.SetActive(false);
            _panelWeaponForPlayer2.SetActive(false);
        }
    }

}
