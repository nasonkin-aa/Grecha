using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private Vector3 _position;
    private Quaternion _rotation;
  

    public void SpawnEnemy(SpawnerController spawnerController,Hero hero,Totem totem)
    {
        GameObject Enemy = Instantiate(_prefab, transform.position, transform.rotation);
        Enemy.GetComponentInChildren<MovingEnemy>().SpawnerController = spawnerController;
        Enemy.GetComponentInChildren<MovingEnemy>().Totem = totem;
        Enemy.GetComponentInChildren<MovingEnemy>().Hero = hero;
        //StartCoroutine(SpawnerCd());
    }
    /*IEnumerator SpawnerCd()
    {
        //yield return new WaitForSeconds(5555);
        
    }*/

}
