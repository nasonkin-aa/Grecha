using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _damageAxe = 50;
    void Start()
    {
        _rb.velocity = transform.right * _speed;
    }
    void Update()
    {
        transform.Rotate(0, 0, -1000f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<MovingEnemy>())
        {
            Debug.Log(Hero.Instance.gameObject);

            MovingEnemy.InstanceEnemy.GetDamage(_damageAxe);
            Destroy(gameObject);
        }
      /*  if (collision.gameObject == MovingEnemy.InstanceEnemy.gameObject)
        {
            MovingEnemy.InstanceEnemy.GetDamage(_damageAxe);

        }*/

    }

}
