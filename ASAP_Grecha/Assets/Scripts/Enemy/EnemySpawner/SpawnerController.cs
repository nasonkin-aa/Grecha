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

    public int DethEmemy;
    private bool _isNight = false;
    private int _maxVave = 0;

    void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        DethEmemy = _maxEnemy;
        int enemyCounter = _maxEnemy;
        while (enemyCounter > 0)
        {
            yield return new WaitForSeconds(1);
            enemyCounter--;
            _enemySpawner.SpawnEnemy(this);
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
