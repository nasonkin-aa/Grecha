using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private Vector3 _position;
    private Quaternion _rotation;
  
    public void SpawnEnemy()
    {
        Instantiate(_prefab, transform.position, transform.rotation);
        //StartCoroutine(SpawnerCd());
    }
    /*IEnumerator SpawnerCd()
    {
        //yield return new WaitForSeconds(5555);
        
    }*/

}
