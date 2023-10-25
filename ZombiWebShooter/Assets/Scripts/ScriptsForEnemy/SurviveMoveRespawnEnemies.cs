using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SurviveMoveRespawnEnemies : MonoBehaviour
{
    [SerializeField] private List<RespawnEnemy> _respawnController = new List<RespawnEnemy>(); //всего 7 респаунеров
	/*
	 0 - обычный
	 1 - быстрый
	 2 - жирный
	 3 - взрывающийся
	 4 - танк
	*/
	[SerializeField] private int _curretWave = 0;
	[SerializeField] private int _moneyForWave = 100;
	[SerializeField] private StatsInMatch _statsInMatch;
	[SerializeField] private SurviveModeInfoView _modeInfoView;
	[SerializeField] private GameObject _panelWin;
	private bool _isReadyForTheNextBattle = false;

	private void Start()
    {
        _statsInMatch = GameObject.FindGameObjectWithTag("MainUI").GetComponent<StatsInMatch>();
		_modeInfoView = GameObject.FindGameObjectWithTag("MainUI").GetComponent<SurviveModeInfoView>();
    }

    private float _koefMoneyForWave = 1.0f;
	private bool _isRespawn = false;
    private void Update()
    {
        if(!_isRespawn)
        {
			_curretWave++;
			StartNewWave();
			_koefMoneyForWave += 0.1f;
        }
		else if (GetSumAllRespawnZombies()<=0 && !_isReadyForTheNextBattle)
        {
			GetMoneyForWave();
			StartCoroutine(GetReadyForTheNextBattle());

		}
		Debug.Log(GetSumAllRespawnZombies());
	}
	private void GetMoneyForWave()
    {
		_statsInMatch.AddMoney(Convert.ToInt32(_moneyForWave * _koefMoneyForWave), true);
    }

	IEnumerator GetReadyForTheNextBattle()
    {
		_isReadyForTheNextBattle = true;
		yield return new WaitForSeconds(1.0f);
		_isRespawn = false;
		
			
		yield return null;
    }
	private void StartNewWave()
    {
		_modeInfoView.UpdateView(_curretWave);
		RespawnZombieByWave();
		_isReadyForTheNextBattle = false;

		_isRespawn = true;
    }
	public int GetNewWave()
    {
		return _curretWave;
    }
	private void RespawnZombieByWave()
    {
		if(_curretWave == 1) //10 обычных
		{ 
			_respawnController[0].RespawnEnemyForOnce(2, 0);
			_respawnController[1].RespawnEnemyForOnce(2, 0);
			_respawnController[2].RespawnEnemyForOnce(1, 0);
			_respawnController[3].RespawnEnemyForOnce(1, 0);
			_respawnController[4].RespawnEnemyForOnce(1, 0);
			_respawnController[5].RespawnEnemyForOnce(1, 0);
			_respawnController[6].RespawnEnemyForOnce(1, 0);
			_respawnController[7].RespawnEnemyForOnce(1, 0);
		}
		else if(_curretWave == 2) //15 обычных и 3 быстрых
		{ 
			_respawnController[0].RespawnEnemyForOnce(2, 0);
			_respawnController[1].RespawnEnemyForOnce(2, 0);
			_respawnController[2].RespawnEnemyForOnce(2, 0);
			_respawnController[3].RespawnEnemyForOnce(2, 0);
			_respawnController[4].RespawnEnemyForOnce(2, 0);
			_respawnController[5].RespawnEnemyForOnce(2, 0);
			_respawnController[6].RespawnEnemyForOnce(3, 0);

			_respawnController[0].RespawnEnemyForOnce(1, 1);
			_respawnController[1].RespawnEnemyForOnce(1, 1);
			_respawnController[2].RespawnEnemyForOnce(1, 1);
		}
		else if(_curretWave == 3) //20 обычных и 10 быстрых
		{ 
			_respawnController[0].RespawnEnemyForOnce(2, 0);
			_respawnController[1].RespawnEnemyForOnce(2, 0);
			_respawnController[2].RespawnEnemyForOnce(2, 0);
			_respawnController[3].RespawnEnemyForOnce(2, 0);
			_respawnController[4].RespawnEnemyForOnce(3, 0);
			_respawnController[5].RespawnEnemyForOnce(3, 0);
			_respawnController[6].RespawnEnemyForOnce(3, 0);
			_respawnController[7].RespawnEnemyForOnce(3, 0);

			_respawnController[0].RespawnEnemyForOnce(2, 1);
			_respawnController[1].RespawnEnemyForOnce(2, 1);
			_respawnController[2].RespawnEnemyForOnce(2, 1);
			_respawnController[3].RespawnEnemyForOnce(2, 1);
			_respawnController[4].RespawnEnemyForOnce(2, 1);
		}
		else if(_curretWave == 4) //40 обычных, 5 толстых, 1 взрывающийся
		{ 
			_respawnController[0].RespawnEnemyForOnce(4, 0);
			_respawnController[1].RespawnEnemyForOnce(4, 0);
			_respawnController[2].RespawnEnemyForOnce(4, 0);
			_respawnController[3].RespawnEnemyForOnce(4, 0);
			_respawnController[4].RespawnEnemyForOnce(6, 0);
			_respawnController[5].RespawnEnemyForOnce(6, 0);
			_respawnController[6].RespawnEnemyForOnce(6, 0);
			_respawnController[7].RespawnEnemyForOnce(6, 0);

			_respawnController[0].RespawnEnemyForOnce(1, 2);
			_respawnController[1].RespawnEnemyForOnce(1, 2);
			_respawnController[2].RespawnEnemyForOnce(1, 2);
			_respawnController[3].RespawnEnemyForOnce(1, 2);
			_respawnController[4].RespawnEnemyForOnce(1, 2);

			_respawnController[5].RespawnEnemyForOnce(1, 3);
		}
		else if (_curretWave == 5) //30 обычных, 15 быстрых
		{ 
			_respawnController[0].RespawnEnemyForOnce(4, 0);
			_respawnController[1].RespawnEnemyForOnce(4, 0);
			_respawnController[2].RespawnEnemyForOnce(4, 0);
			_respawnController[3].RespawnEnemyForOnce(4, 0);
			_respawnController[4].RespawnEnemyForOnce(4, 0);
			_respawnController[5].RespawnEnemyForOnce(4, 0);
			_respawnController[6].RespawnEnemyForOnce(4, 0);
			_respawnController[7].RespawnEnemyForOnce(5, 0);

			_respawnController[0].RespawnEnemyForOnce(2, 1);
			_respawnController[1].RespawnEnemyForOnce(2, 1);
			_respawnController[2].RespawnEnemyForOnce(2, 1);
			_respawnController[3].RespawnEnemyForOnce(2, 1);
			_respawnController[4].RespawnEnemyForOnce(2, 1);
			_respawnController[6].RespawnEnemyForOnce(2, 1);
			_respawnController[7].RespawnEnemyForOnce(3, 1);
		}
		else if (_curretWave == 6) //35 обычных 10 быстрых 5 толстых
        {
			_respawnController[0].RespawnEnemyForOnce(4, 0);
			_respawnController[1].RespawnEnemyForOnce(4, 0);
			_respawnController[2].RespawnEnemyForOnce(5, 0);
			_respawnController[3].RespawnEnemyForOnce(5, 0);
			_respawnController[4].RespawnEnemyForOnce(5, 0);
			_respawnController[5].RespawnEnemyForOnce(5, 0);
			_respawnController[6].RespawnEnemyForOnce(5, 0);
			_respawnController[7].RespawnEnemyForOnce(5, 0);

			_respawnController[0].RespawnEnemyForOnce(2, 1);
			_respawnController[1].RespawnEnemyForOnce(2, 1);
			_respawnController[2].RespawnEnemyForOnce(2, 1);
			_respawnController[3].RespawnEnemyForOnce(2, 1);
			_respawnController[4].RespawnEnemyForOnce(2, 1);

			_respawnController[6].RespawnEnemyForOnce(2, 2);
			_respawnController[7].RespawnEnemyForOnce(3, 2);
		}
		else if (_curretWave == 7) //40 обычных 5 быстрых 3 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(5, 0);
			_respawnController[1].RespawnEnemyForOnce(5, 0);
			_respawnController[2].RespawnEnemyForOnce(6, 0);
			_respawnController[3].RespawnEnemyForOnce(6, 0);
			_respawnController[4].RespawnEnemyForOnce(6, 0);
			_respawnController[5].RespawnEnemyForOnce(5, 0);
			_respawnController[6].RespawnEnemyForOnce(5, 0);
			_respawnController[7].RespawnEnemyForOnce(5, 0);

			_respawnController[0].RespawnEnemyForOnce(1, 1);
			_respawnController[1].RespawnEnemyForOnce(2, 1);
			_respawnController[2].RespawnEnemyForOnce(2, 1);

			_respawnController[3].RespawnEnemyForOnce(1, 3);
			_respawnController[4].RespawnEnemyForOnce(1, 3);
			_respawnController[6].RespawnEnemyForOnce(1, 3);
		}
		else if (_curretWave == 8) //80 обычных
        {
			_respawnController[0].RespawnEnemyForOnce(11, 0);
			_respawnController[1].RespawnEnemyForOnce(11, 0);
			_respawnController[2].RespawnEnemyForOnce(11, 0);
			_respawnController[3].RespawnEnemyForOnce(11, 0);
			_respawnController[4].RespawnEnemyForOnce(11, 0);
			_respawnController[5].RespawnEnemyForOnce(12, 0);
			_respawnController[6].RespawnEnemyForOnce(12, 0);
			_respawnController[7].RespawnEnemyForOnce(12, 0);
		}
		else if (_curretWave == 9) //25 быстрых
        {
			_respawnController[0].RespawnEnemyForOnce(4, 1);
			_respawnController[1].RespawnEnemyForOnce(4, 1);
			_respawnController[2].RespawnEnemyForOnce(4, 1);
			_respawnController[3].RespawnEnemyForOnce(4, 1);
			_respawnController[4].RespawnEnemyForOnce(3, 1);
			_respawnController[5].RespawnEnemyForOnce(3, 1);
			_respawnController[6].RespawnEnemyForOnce(3, 1);
			_respawnController[7].RespawnEnemyForOnce(3, 1);
		}
		else if (_curretWave == 10) //10 быстрых, 10 толстых и 1 танк
        {
			_respawnController[0].RespawnEnemyForOnce(3, 1);
			_respawnController[1].RespawnEnemyForOnce(3, 1);
			_respawnController[2].RespawnEnemyForOnce(4, 1);

			_respawnController[3].RespawnEnemyForOnce(3, 2);
			_respawnController[4].RespawnEnemyForOnce(3, 2);
			_respawnController[5].RespawnEnemyForOnce(3, 2);
			_respawnController[6].RespawnEnemyForOnce(1, 2);

			_respawnController[7].RespawnEnemyForOnce(1, 4);
		}
		else if (_curretWave == 11) //100 обычных зомби
        {
			_respawnController[0].RespawnEnemyForOnce(14, 0);
			_respawnController[1].RespawnEnemyForOnce(14, 0);
			_respawnController[2].RespawnEnemyForOnce(14, 0);
			_respawnController[3].RespawnEnemyForOnce(14, 0);
			_respawnController[4].RespawnEnemyForOnce(14, 0);
			_respawnController[5].RespawnEnemyForOnce(14, 0);
			_respawnController[6].RespawnEnemyForOnce(15, 0);
			_respawnController[7].RespawnEnemyForOnce(15, 0);
		}
		else if (_curretWave == 12) //30 быстрых, 3 толстых
        {
			_respawnController[0].RespawnEnemyForOnce(5, 1);
			_respawnController[1].RespawnEnemyForOnce(5, 1);
			_respawnController[2].RespawnEnemyForOnce(4, 1);
			_respawnController[3].RespawnEnemyForOnce(4, 1);
			_respawnController[4].RespawnEnemyForOnce(4, 1);
			_respawnController[5].RespawnEnemyForOnce(4, 1);
			_respawnController[6].RespawnEnemyForOnce(4, 1);
			_respawnController[7].RespawnEnemyForOnce(4, 1);

			_respawnController[5].RespawnEnemyForOnce(1, 2);
			_respawnController[6].RespawnEnemyForOnce(1, 2);
			_respawnController[7].RespawnEnemyForOnce(1, 2);
		}
		else if (_curretWave == 13) //15 быстрых 5 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(1, 1);
			_respawnController[1].RespawnEnemyForOnce(1, 1);
			_respawnController[2].RespawnEnemyForOnce(1, 1);
			_respawnController[3].RespawnEnemyForOnce(1, 1);
			_respawnController[4].RespawnEnemyForOnce(1, 1);
			_respawnController[5].RespawnEnemyForOnce(1, 1);
			_respawnController[6].RespawnEnemyForOnce(1, 1);
			_respawnController[7].RespawnEnemyForOnce(2, 1);

			_respawnController[5].RespawnEnemyForOnce(2, 3);
			_respawnController[6].RespawnEnemyForOnce(2, 3);
			_respawnController[7].RespawnEnemyForOnce(1, 3);
		}
		else if (_curretWave == 14) //20 быстрых 10 толстых 5 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(1, 1);
			_respawnController[1].RespawnEnemyForOnce(1, 1);
			_respawnController[2].RespawnEnemyForOnce(2, 1);
			_respawnController[3].RespawnEnemyForOnce(2, 1);
			_respawnController[4].RespawnEnemyForOnce(2, 1);
			_respawnController[5].RespawnEnemyForOnce(2, 1);
			_respawnController[6].RespawnEnemyForOnce(2, 1);
			_respawnController[7].RespawnEnemyForOnce(2, 1);

			_respawnController[0].RespawnEnemyForOnce(3, 2);
			_respawnController[1].RespawnEnemyForOnce(3, 2);
			_respawnController[2].RespawnEnemyForOnce(4, 2);

			_respawnController[5].RespawnEnemyForOnce(2, 3);
			_respawnController[6].RespawnEnemyForOnce(2, 3);
			_respawnController[7].RespawnEnemyForOnce(1, 3);

		}
		else if (_curretWave == 15) //100 обычных 10 быстрых
        {
			_respawnController[0].RespawnEnemyForOnce(14, 0);
			_respawnController[1].RespawnEnemyForOnce(14, 0);
			_respawnController[2].RespawnEnemyForOnce(14, 0);
			_respawnController[3].RespawnEnemyForOnce(14, 0);
			_respawnController[4].RespawnEnemyForOnce(14, 0);
			_respawnController[5].RespawnEnemyForOnce(14, 0);
			_respawnController[6].RespawnEnemyForOnce(15, 0);
			_respawnController[7].RespawnEnemyForOnce(15, 0);

			_respawnController[0].RespawnEnemyForOnce(3, 1);
			_respawnController[1].RespawnEnemyForOnce(3, 1);
			_respawnController[2].RespawnEnemyForOnce(4, 1);
		}
		else if(_curretWave == 16) //50 обычных 20 быстрых
        {
			_respawnController[0].RespawnEnemyForOnce(7, 0);
			_respawnController[1].RespawnEnemyForOnce(7, 0);
			_respawnController[2].RespawnEnemyForOnce(7, 0);
			_respawnController[3].RespawnEnemyForOnce(7, 0);
			_respawnController[4].RespawnEnemyForOnce(7, 0);
			_respawnController[5].RespawnEnemyForOnce(7, 0);
			_respawnController[6].RespawnEnemyForOnce(8, 0);

			_respawnController[7].RespawnEnemyForOnce(20, 1);
		}
		else if (_curretWave == 17) //20 толстых
		{
			_respawnController[0].RespawnEnemyForOnce(2, 2);
			_respawnController[1].RespawnEnemyForOnce(3, 2);
			_respawnController[2].RespawnEnemyForOnce(3, 2);
			_respawnController[3].RespawnEnemyForOnce(3, 2);
			_respawnController[4].RespawnEnemyForOnce(3, 2);
			_respawnController[5].RespawnEnemyForOnce(3, 2);
			_respawnController[6].RespawnEnemyForOnce(3, 2);
			_respawnController[7].RespawnEnemyForOnce(3, 2);
		}
		else if (_curretWave == 18) //30 быстрых
        {
			_respawnController[0].RespawnEnemyForOnce(4, 1);
			_respawnController[1].RespawnEnemyForOnce(4, 1);
			_respawnController[2].RespawnEnemyForOnce(4, 1);
			_respawnController[3].RespawnEnemyForOnce(4, 1);
			_respawnController[4].RespawnEnemyForOnce(4, 1);
			_respawnController[5].RespawnEnemyForOnce(4, 1);
			_respawnController[6].RespawnEnemyForOnce(5, 1);
			_respawnController[7].RespawnEnemyForOnce(5, 1);
		}
		else if (_curretWave == 19) //50 обычных 20 быстрых 10 толстых 5 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(7, 0);
			_respawnController[1].RespawnEnemyForOnce(7, 0);
			_respawnController[2].RespawnEnemyForOnce(7, 0);
			_respawnController[3].RespawnEnemyForOnce(7, 0);
			_respawnController[4].RespawnEnemyForOnce(7, 0);
			_respawnController[5].RespawnEnemyForOnce(7, 0);
			_respawnController[6].RespawnEnemyForOnce(8, 0);

			_respawnController[7].RespawnEnemyForOnce(20, 1);

			_respawnController[0].RespawnEnemyForOnce(1, 2);
			_respawnController[1].RespawnEnemyForOnce(1, 2);
			_respawnController[2].RespawnEnemyForOnce(1, 2);
			_respawnController[3].RespawnEnemyForOnce(1, 2);
			_respawnController[4].RespawnEnemyForOnce(1, 2);
			_respawnController[5].RespawnEnemyForOnce(1, 2);
			_respawnController[6].RespawnEnemyForOnce(1, 2);

			_respawnController[7].RespawnEnemyForOnce(5, 3);
		}
		else if (_curretWave == 20) //50 обычных 5 танков
        {
			_respawnController[0].RespawnEnemyForOnce(7, 0);
			_respawnController[1].RespawnEnemyForOnce(7, 0);
			_respawnController[2].RespawnEnemyForOnce(7, 0);
			_respawnController[3].RespawnEnemyForOnce(7, 0);
			_respawnController[4].RespawnEnemyForOnce(7, 0);
			_respawnController[5].RespawnEnemyForOnce(7, 0);
			_respawnController[6].RespawnEnemyForOnce(8, 0);

			_respawnController[0].RespawnEnemyForOnce(1, 4);
			_respawnController[1].RespawnEnemyForOnce(1, 4);
			_respawnController[2].RespawnEnemyForOnce(1, 4);
			_respawnController[3].RespawnEnemyForOnce(1, 4);
			_respawnController[4].RespawnEnemyForOnce(1, 4);
		}			
		else if (_curretWave == 21) //200 обычных 
        {
			_respawnController[0].RespawnEnemyForOnce(28, 0);
			_respawnController[1].RespawnEnemyForOnce(28, 0);
			_respawnController[2].RespawnEnemyForOnce(28, 0);
			_respawnController[3].RespawnEnemyForOnce(28, 0);
			_respawnController[4].RespawnEnemyForOnce(28, 0);
			_respawnController[5].RespawnEnemyForOnce(28, 0);
			_respawnController[6].RespawnEnemyForOnce(30, 0);
			_respawnController[7].RespawnEnemyForOnce(30, 0);
		}
		else if(_curretWave == 22) //100 обычных 20 быстрых 5 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(14, 0);
			_respawnController[1].RespawnEnemyForOnce(14, 0);
			_respawnController[2].RespawnEnemyForOnce(14, 0);
			_respawnController[3].RespawnEnemyForOnce(14, 0);
			_respawnController[4].RespawnEnemyForOnce(14, 0);
			_respawnController[5].RespawnEnemyForOnce(14, 0);
			_respawnController[6].RespawnEnemyForOnce(15, 0);
			_respawnController[7].RespawnEnemyForOnce(15, 0);

			_respawnController[0].RespawnEnemyForOnce(6, 1);
			_respawnController[1].RespawnEnemyForOnce(6, 1);
			_respawnController[2].RespawnEnemyForOnce(8, 1);

			_respawnController[7].RespawnEnemyForOnce(5, 3);
		}
		else if (_curretWave == 23) //10 толстых 20 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(1, 2);
			_respawnController[1].RespawnEnemyForOnce(1, 2);
			_respawnController[2].RespawnEnemyForOnce(1, 2);
			_respawnController[3].RespawnEnemyForOnce(1, 2);
			_respawnController[4].RespawnEnemyForOnce(1, 2);
			_respawnController[5].RespawnEnemyForOnce(2, 2);
			_respawnController[6].RespawnEnemyForOnce(2, 2);
			_respawnController[7].RespawnEnemyForOnce(2, 2);

			_respawnController[0].RespawnEnemyForOnce(3, 3);
			_respawnController[1].RespawnEnemyForOnce(3, 3);
			_respawnController[2].RespawnEnemyForOnce(3, 3);
			_respawnController[3].RespawnEnemyForOnce(3, 3);
			_respawnController[4].RespawnEnemyForOnce(3, 3);
			_respawnController[5].RespawnEnemyForOnce(3, 3);
			_respawnController[6].RespawnEnemyForOnce(3, 3);
			_respawnController[7].RespawnEnemyForOnce(2, 3);
		}
		else if (_curretWave == 24) //100 обычных 20 быстрых 10 толстых 5 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(14, 0);
			_respawnController[1].RespawnEnemyForOnce(14, 0);
			_respawnController[2].RespawnEnemyForOnce(14, 0);
			_respawnController[3].RespawnEnemyForOnce(14, 0);
			_respawnController[4].RespawnEnemyForOnce(14, 0);
			_respawnController[5].RespawnEnemyForOnce(14, 0);
			_respawnController[6].RespawnEnemyForOnce(15, 0);
			_respawnController[7].RespawnEnemyForOnce(15, 0);

			_respawnController[0].RespawnEnemyForOnce(6, 1);
			_respawnController[1].RespawnEnemyForOnce(6, 1);
			_respawnController[2].RespawnEnemyForOnce(8, 1);

			_respawnController[0].RespawnEnemyForOnce(1, 2);
			_respawnController[1].RespawnEnemyForOnce(1, 2);
			_respawnController[2].RespawnEnemyForOnce(1, 2);
			_respawnController[3].RespawnEnemyForOnce(1, 2);
			_respawnController[4].RespawnEnemyForOnce(1, 2);
			_respawnController[5].RespawnEnemyForOnce(2, 2);
			_respawnController[6].RespawnEnemyForOnce(2, 2);
			_respawnController[7].RespawnEnemyForOnce(2, 2);

			_respawnController[7].RespawnEnemyForOnce(5, 3);
		}
		else if (_curretWave == 25) //100 обычных 20 быстрых 20 толстых
        {
			_respawnController[0].RespawnEnemyForOnce(14, 0);
			_respawnController[1].RespawnEnemyForOnce(14, 0);
			_respawnController[2].RespawnEnemyForOnce(14, 0);
			_respawnController[3].RespawnEnemyForOnce(14, 0);
			_respawnController[4].RespawnEnemyForOnce(14, 0);
			_respawnController[5].RespawnEnemyForOnce(14, 0);
			_respawnController[6].RespawnEnemyForOnce(15, 0);
			_respawnController[7].RespawnEnemyForOnce(15, 0);

			_respawnController[0].RespawnEnemyForOnce(6, 1);
			_respawnController[1].RespawnEnemyForOnce(6, 1);
			_respawnController[2].RespawnEnemyForOnce(8, 1);

			
			_respawnController[5].RespawnEnemyForOnce(6, 2);
			_respawnController[6].RespawnEnemyForOnce(6, 2);
			_respawnController[7].RespawnEnemyForOnce(8, 2);
		}
		else if (_curretWave == 26) //30 взрывающихся
        {
			_respawnController[0].RespawnEnemyForOnce(4, 3);
			_respawnController[1].RespawnEnemyForOnce(4, 3);
			_respawnController[2].RespawnEnemyForOnce(4, 3);
			_respawnController[3].RespawnEnemyForOnce(4, 3);
			_respawnController[4].RespawnEnemyForOnce(4, 3);
			_respawnController[5].RespawnEnemyForOnce(4, 3);
			_respawnController[6].RespawnEnemyForOnce(3, 3);
			_respawnController[7].RespawnEnemyForOnce(3, 3);
		}
		else if (_curretWave == 27) //40 толыстых
        {
			_respawnController[0].RespawnEnemyForOnce(5, 2);
			_respawnController[1].RespawnEnemyForOnce(5, 2);
			_respawnController[2].RespawnEnemyForOnce(5, 2);
			_respawnController[3].RespawnEnemyForOnce(5, 2);
			_respawnController[4].RespawnEnemyForOnce(5, 2);
			_respawnController[5].RespawnEnemyForOnce(5, 2);
			_respawnController[6].RespawnEnemyForOnce(5, 2);
			_respawnController[7].RespawnEnemyForOnce(5, 2);
		}
		else if (_curretWave == 28) //50 быстрых
        {
			_respawnController[0].RespawnEnemyForOnce(7, 1);
			_respawnController[1].RespawnEnemyForOnce(7, 1);
			_respawnController[2].RespawnEnemyForOnce(6, 1);
			_respawnController[3].RespawnEnemyForOnce(6, 1);
			_respawnController[4].RespawnEnemyForOnce(6, 1);
			_respawnController[5].RespawnEnemyForOnce(6, 1);
			_respawnController[6].RespawnEnemyForOnce(6, 1);
			_respawnController[7].RespawnEnemyForOnce(6, 1);
		}
		else if (_curretWave == 29) //300 обычных
        {
			_respawnController[0].RespawnEnemyForOnce(83, 0);
			_respawnController[1].RespawnEnemyForOnce(83, 0);
			_respawnController[2].RespawnEnemyForOnce(83, 0);
			_respawnController[3].RespawnEnemyForOnce(83, 0);
			_respawnController[4].RespawnEnemyForOnce(83, 0);
			_respawnController[5].RespawnEnemyForOnce(83, 0);
			_respawnController[6].RespawnEnemyForOnce(84, 0);
			_respawnController[7].RespawnEnemyForOnce(84, 0);
		}
		else if (_curretWave == 30) //10 танков
        {
			_respawnController[0].RespawnEnemyForOnce(1, 4);
			_respawnController[1].RespawnEnemyForOnce(1, 4);
			_respawnController[2].RespawnEnemyForOnce(1, 4);
			_respawnController[3].RespawnEnemyForOnce(1, 4);
			_respawnController[4].RespawnEnemyForOnce(1, 4);
			_respawnController[5].RespawnEnemyForOnce(1, 4);
			_respawnController[6].RespawnEnemyForOnce(2, 4);
			_respawnController[7].RespawnEnemyForOnce(2, 4);
		}
		else
        {
			Time.timeScale = 0.0f;
			Debug.Log("Победа"); //УРА, ПОБЕДА
        }

	}
	public int GetSumAllRespawnZombies()
    {
		int sum = 0;	
		foreach (RespawnEnemy respawner in _respawnController)
		{
			sum+= respawner.GetCountOfZombie();
		}

		return sum;
    }
}
