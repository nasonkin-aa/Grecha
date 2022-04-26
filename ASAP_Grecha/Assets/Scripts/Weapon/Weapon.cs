using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject _bulletPrefab;
    //public int timeDelayAttack = 2;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
       
        GameObject Axe = Instantiate(_bulletPrefab, _firePoint.position,_firePoint.localRotation);
       // Axe.transform.position = 
    }
}
    