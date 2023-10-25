using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLanguage : MonoBehaviour
{
    public void SetLanguageAsRus()
    {
        ClassLanguage.SetCurretLanguage(Language.rus);
    }
    public void SetLanguageAsEng()
    {
        ClassLanguage.SetCurretLanguage(Language.eng);
    }
}
