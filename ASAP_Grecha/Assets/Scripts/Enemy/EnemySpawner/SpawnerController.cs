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
    protected GameObject _enemyPrefab;
    [SerializeField]
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private Totem _totem;
    [SerializeField]
    private Hero _hero;
    [SerializeField]
    private EnemySpawner[] _spawners ;

    public int DethEmemy;
    private bool _isNight = false;
    private int _maxVave = 0;

    void Start()
    {
        _spawners = FindObjectsOfType<EnemySpawner>();
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        DethEmemy = _maxEnemy;
        int enemyCounter = _maxEnemy;
        int SpavnerNumber ;
        while (enemyCounter > 0)
        {
            yield return new WaitForSeconds(1);
            enemyCounter--;
            SpavnerNumber = Random.Range(0, _spawners.Length);
            _spawners[SpavnerNumber].SpawnEnemy(this,_totem);
        }
        Debug.Log("End spawn");
        _isNight = true;
        _maxEnemy += 3;
    }
    private void Update()
    {
      if( _isNight && _maxVave < 3 && DethEmemy == 0)
        {
            Debug.Log("new vave");
            _maxVave++;
            StartCoroutine(Spawner());

        }
    }
}
