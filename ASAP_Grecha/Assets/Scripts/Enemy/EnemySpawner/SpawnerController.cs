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
    private int _maxEnemy = 3;
    protected GameObject _enemyPrefab;
    [SerializeField]
    private EnemySpawner _enemySpawner;

    void Start()
    {
        /*_enemySpawner = new EnemySpawner(_enemyPrefab,transform.position,)*/
        while(_maxEnemy > 0)
        {
            _maxEnemy--;
            _enemySpawner.SpawnEnemy();
        }
    }
    void Update()
    {
        
    }
}
