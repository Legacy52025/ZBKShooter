using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OtherLanguage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _textInEnglish;
    [SerializeField] private string _textInRussian;
    
    private void Start()
    {
        CheckLanguage();
    }
    private void Update()
    {
        CheckLanguage();
    }
    public void CheckLanguage()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if (ClassLanguage.GetCurretLanguage() != Language.rus)
        {
            _text.text = _textInEnglish;
        }
        else
        {
            _text.text = _textInRussian;
        }
    }
}
