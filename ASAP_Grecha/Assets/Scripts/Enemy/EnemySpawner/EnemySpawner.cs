using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private Vector3 _position;
    private Quaternion _rotation;

    public EnemySpawner(GameObject prefab,Vector3 pisition, Quaternion rotation)
    {
        _prefab = prefab;
        _position = pisition;
        _rotation = rotation;
    }
  
    public void SpawnEnemy()
    {
        StartCoroutine(SpawnerCd());
    }
    IEnumerator SpawnerCd()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        Instantiate(_prefab, transform.position, transform.rotation);
    }

}
