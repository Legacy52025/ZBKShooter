using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForRespawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _respawners = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            for(int i = 0;i< _respawners.Count;i++)
            {
                _respawners[i].GetComponent<RespawnEnemy>().RespawnByTrigger();
            }
            Destroy(gameObject);
        }

        
    }

}
