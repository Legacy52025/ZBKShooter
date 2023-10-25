using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _numberOfHeal;
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("������� ����������");
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("�������� �� ������ ��������");
            other.gameObject.GetComponent<Player>().GetHeal(_numberOfHeal);

            Destroy(gameObject);
        }
    }
   
}
