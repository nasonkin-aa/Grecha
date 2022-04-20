using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _damageAxe = 50;
    
   /* [SerializeField]
    private MovingEnemy _movingEnemy;*/
    void Start()
    {
        Vector2 _mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _derection = _mousPos - new Vector2(transform.position.x, transform.position.y);
        _rb.velocity = _derection.normalized * _speed;
    }
    void Update()
    {
        transform.Rotate(0, 0, -1000f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<MovingEnemy>())
        {
            collision.transform.GetComponent<MovingEnemy>().GetDamage(_damageAxe);
            Destroy(gameObject);
        }
    }

}
