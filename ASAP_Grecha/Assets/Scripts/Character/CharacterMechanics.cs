using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    private float speed = 1.5f;
    
    [SerializeField]
    private GameObject _arrowPref;
    private GameObject _player;

    void Update()
    {
        AimAndShoot();
        CharacterMove();
    }
    void CharacterMove()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
    void AimAndShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 shootingDirection = mousPos - (Vector2)transform.position ;
            Quaternion quaternion = Quaternion.Euler(0,0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            shootingDirection.Normalize();
            GameObject arrow = Instantiate(_arrowPref, transform.position, quaternion);
            arrow.GetComponent<Arrow>().velocity = shootingDirection * 3;
        }

    }
}
