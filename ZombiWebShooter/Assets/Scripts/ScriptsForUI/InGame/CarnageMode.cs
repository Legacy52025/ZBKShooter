using UnityEngine;
using TMPro;

public class CarnageMode : MonoBehaviour
{
    private int _countZombie = 0;
    [SerializeField] private int _bonusForGame = 1000;
    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private StatsInMatch _statsInMatch;
    [SerializeField] private OpenMenu _openMenu;
    
    private bool _isEnd = false;

    private void Start()
    {
        _statsInMatch = GameObject.FindGameObjectWithTag("MainUI").GetComponent<StatsInMatch>();
        _openMenu = GameObject.FindGameObjectWithTag("MainUI").GetComponent<OpenMenu>();
    }
    private void Update()
    {
        _textCount.text = GetCountZombie().ToString();
        if (!_isEnd)
        {

            if (_countZombie == 0)
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0.0f;
        _isEnd = true;
        _statsInMatch.AddMoney(_bonusForGame, true);
        _statsInMatch.AddMoneyForEndGame();
        _openMenu.SetGameIsEnd();
        _winPanel.SetActive(true);
        Debug.Log("Win");
    }

    public int GetCountZombie()
    {
        _countZombie = GameObject.FindGameObjectsWithTag("Zombie").Length;
        return _countZombie;
    }
}
