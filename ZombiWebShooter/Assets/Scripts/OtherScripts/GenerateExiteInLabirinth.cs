using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateExiteInLabirinth : MonoBehaviour
{
    [SerializeField] private List<GameObject> _exites;
    [SerializeField] private List<GameObject> _winRooms;

    private void Start()
    {
        GenerateExite();
    }
    public void GenerateExite()
    {
        int _numberExiteInMatch;
        _numberExiteInMatch = Random.Range(0, _exites.Count);
        _exites[_numberExiteInMatch].SetActive(false);

        for (int i = 0; i < _winRooms.Count; i++)
        {
            if (i != _numberExiteInMatch)
            {
                _winRooms[i].SetActive(false);
            }
        }

    }




}
