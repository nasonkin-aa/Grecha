using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private CursorManager.CursorAnimation cursorManager;
    public Transform _firePoint;
    public GameObject _bulletPrefab;
    public bool doubleAxe;
    private bool _attackFlag = true;
    [SerializeField] public float delayAttack;
    //public int timeDelayAttack = 2;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _attackFlag)
        {
            _attackFlag = false;
            Shoot();
            if (doubleAxe) Invoke("Shoot", 0.1f);
            CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Reload);
            Invoke("AttackFlagOn", delayAttack);
        }
    }
    void Shoot()
    {
        GameObject Axe = Instantiate(_bulletPrefab, _firePoint.position,_firePoint.localRotation);

       // Axe.transform.position = 
    }

    void AttackFlagOn()
    {
        _attackFlag = true;
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
    }
}
    