//using System;
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
    [SerializeField]
    protected GameObject _enemyWolfPrefab;
    [SerializeField]
    protected GameObject _enemyBirdPrefab;
    [SerializeField]
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private Totem _totem;
    [SerializeField]
    private Hero _hero;
    [SerializeField]
    private EnemySpawner[] _spawners ;
    [SerializeField]
    private Camp _camp;

    public int DethEmemy;
    private bool _isNight = false;
    private int _maxVave = 0;

    void Awake()
    {
        _spawners = FindObjectsOfType<EnemySpawner>();
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        DethEmemy = _maxEnemy;
        int enemyCounter = _maxEnemy;
        while (enemyCounter > 0)
        {
            int SpawnPlace = Random.Range(0, _spawners.Length);
            yield return new WaitForSeconds(Random.Range(1,5));
            enemyCounter--;
            if (SpawnPlace < 2)
            {
                //SpavnerNumber = Random.Range(0, _spawners.Length);
                _spawners[SpawnPlace].SpawnEnemy(_enemyBirdPrefab,this, _totem, _camp);
            }
            else
            {
                _spawners[SpawnPlace].SpawnEnemy(_enemyWolfPrefab, this, _totem,_camp);
            }
        }
        Debug.Log("End spawn");
    }
    private void Update()
    {
      if( _isNight || DethEmemy == 0)
        {
            Debug.Log("new wave");
            _maxVave++;
            _maxEnemy +=3;
            StartCoroutine(Spawner());
        }
    }
}
