using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RespawnEnemy : MonoBehaviour
{
	[SerializeField] List<GameObject> _enemyInRespawn = new List<GameObject>();
	[SerializeField] private int _kolEnemyInRespawn = 1;
	[SerializeField] private bool _isRespawnInStart = false;
	[SerializeField] private int _kolRespawns = 1;
	private List<GameObject> _respawnersEnemy = new List<GameObject>();
	[SerializeField] private bool _isLastEnemyInMap = false;
	
	void Start()
	{
		if (_isRespawnInStart)
		{
			RespawnEnemyForOnce(_kolEnemyInRespawn, 0);
		}
	//	StartCoroutine(RespawnCorountine());
		
	}

	public List<GameObject> GetAllEnemyFromThisRespawner()
    {
		return _enemyInRespawn;
    }

	public void RespawnByTrigger()
    {
		if (_kolRespawns > 0)
		{
			RespawnEnemyForOnce(_kolEnemyInRespawn, 0);
			_kolRespawns--;
		}

	}
	public void RespawnEnemyForOnce(int _kol, int _id)
    {
		int _randomZoneX;
		int _randomZoneZ;
		while(_kol>0)
        {
			_randomZoneX = Random.Range(-3, 3);
			_randomZoneZ = Random.Range(-3, 3);
			GameObject _zombie = Instantiate(_enemyInRespawn[_id]);
			//_zombie.w = gameObject.transform.position;
			_zombie.GetComponent<NavMeshAgent>().Warp(new Vector3(transform.position.x+_randomZoneX, transform.position.y, transform.position.z+_randomZoneZ));
			_respawnersEnemy.Add(_zombie);
			_kol--;
		}
		if(_isLastEnemyInMap)
        {
			Debug.Log("Прошли проверку, что это последний враг на карте");
			StartCoroutine( CheckAliveZombie() );
        }
    }

	IEnumerator CheckAliveZombie()
    {
		while (true)
		{
			yield return new WaitForSeconds(1.0f);
			Debug.Log("Количество зомби " + GetCountOfZombie());

			if (GetCountOfZombie() <= 0)
			{
				Debug.Log("Зомби погибли, запускаем катсцену");
				GameObject.FindGameObjectWithTag("CutSceneObject").GetComponent<StartCutScene>().StartCutScenes();
				yield return null;
			}
		}
	}

	public int GetCountOfZombie()
    {
		int kol = 0;
		for(int i = 0;i<_respawnersEnemy.Count;i++)
        {
			if(_respawnersEnemy[i] != null)
            {
				kol++;
            }
        }
		if(kol == 0)
        {
			ClearListZombie();
			return 0;
        }
		return kol;
    }

	public void ClearListZombie()
    {
		_respawnersEnemy.Clear();
    }

}
