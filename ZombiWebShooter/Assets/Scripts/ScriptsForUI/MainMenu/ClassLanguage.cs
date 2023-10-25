using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class ClassLanguage
{
    static private Language _curretLanguage = Language.rus;

    static public Language GetCurretLanguage()
    {
        return _curretLanguage;
    }
    static public void SetCurretLanguage(Language _newLanguage)
    {
        _curretLanguage = _newLanguage;
    }

}
public enum Language
{
    rus = 0,
    eng = 1
}