using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    [SerializeField]
    //private GameObject _prefabWolf;
    private Vector3 _position;
    private Quaternion _rotation;
  

    public void SpawnEnemy(GameObject prefabEnemy,SpawnerController spawnerController,Totem totem)
    {
        GameObject Enemy = Instantiate(prefabEnemy, transform.position, transform.rotation);
        Enemy.GetComponentInChildren<MovingEnemy>().SpawnerController = spawnerController;
        Enemy.GetComponentInChildren<MovingEnemy>().Totem = totem;
        //StartCoroutine(SpawnerCd());
    }

}
