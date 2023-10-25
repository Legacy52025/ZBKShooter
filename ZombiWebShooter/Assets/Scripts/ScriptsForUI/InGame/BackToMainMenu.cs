using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _loadScreen;
    public void LoadMainMenu(int _idScene = 0)
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadingScreen(_idScene));
    }

    private IEnumerator LoadingScreen(int _idScene)
    {
        _loadScreen.SetActive(true);
        AsyncOperation _operationLoad = SceneManager.LoadSceneAsync(_idScene);
        while(!_operationLoad.isDone)
        {
            float _loadProgress = Mathf.Clamp01(_operationLoad.progress / .9f);
            _slider.value = _loadProgress;
            yield return null;
        }
    }

}
