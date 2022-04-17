using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    /*[SerializeField]
    private EnemySpawner[] _airSpawner;
    [SerializeField]
    private EnemySpawner[] _groundSpawner;*/
    [SerializeField]
    private int _maxEnemy;
    protected GameObject _enemyPrefab;
    [SerializeField]
    private EnemySpawner _enemySpawner;


    private int _dethEmemy;
    private bool _isNight;
    private bool _maxVave;

    void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        while (_maxEnemy > 0)
        {
            yield return new WaitForSeconds(2);
            _maxEnemy--;
            _enemySpawner.SpawnEnemy();
        }
    }
    void Update()
    {
        
    }
}
