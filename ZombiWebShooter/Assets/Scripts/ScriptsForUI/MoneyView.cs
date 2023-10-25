using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField]private Money _money;
    [SerializeField]private TextMeshProUGUI _textMoney;
    void Update()
    {
        _textMoney.text = _money.GetMoney().ToString();
    }
}
