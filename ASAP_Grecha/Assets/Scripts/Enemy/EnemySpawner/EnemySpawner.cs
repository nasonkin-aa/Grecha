using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabWolf;
    private Vector3 _position;
    private Quaternion _rotation;
  

    public void SpawnEnemy(SpawnerController spawnerController,Totem totem)
    {
        GameObject Enemy = Instantiate(_prefabWolf, transform.position, transform.rotation);
        Enemy.GetComponentInChildren<MovingEnemy>().SpawnerController = spawnerController;
        Enemy.GetComponentInChildren<MovingEnemy>().Totem = totem;
        //StartCoroutine(SpawnerCd());
    }

}
