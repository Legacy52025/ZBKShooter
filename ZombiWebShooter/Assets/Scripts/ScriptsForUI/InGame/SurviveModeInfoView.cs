using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurviveModeInfoView : MonoBehaviour
{
    [SerializeField] private GameObject _panelNewWave;
    [SerializeField] private TextMeshProUGUI _textViewNumberOfWave;
    [SerializeField] private InfoManager _infoManager;
    [SerializeField] private TextMeshProUGUI _textNumberOfZombie;
    [SerializeField] private SurviveMoveRespawnEnemies _surviveMoveRespawnEnemies;

    private void Update()
    {
        _textNumberOfZombie.text = _surviveMoveRespawnEnemies.GetSumAllRespawnZombies().ToString();
    }

    public void UpdateView(int _curretWave)
    {
        _panelNewWave.SetActive(true);
        _textViewNumberOfWave.text = _curretWave.ToString();
        StartCoroutine(HideViewPanelInfoWave());
    }
   
    IEnumerator HideViewPanelInfoWave()
    {
        yield return new WaitForSeconds(2.0f);
        _panelNewWave.SetActive(false);
        yield return null;
    }

}
