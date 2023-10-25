using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNumberPlayer : MonoBehaviour
{
    public void SetTwoPlayers()
    {
        PlayerPrefs.SetInt("NumberPlayers", 2);
    }
    public void SetOnePlayer()
    {
        PlayerPrefs.SetInt("NumberPlayers", 1);
    }
}
