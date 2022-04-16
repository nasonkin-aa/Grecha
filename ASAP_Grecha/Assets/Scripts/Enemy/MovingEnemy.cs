using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour 
{
    private float _speed = 4f;
    private Vector3 _dir;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _dir = transform.right;
    }
    private void Move()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * _dir.x * 0.7f, 0.1f);
        if(collider.Length > 0)
        {
            _dir *= -1;
        }
        transform.position = Vector3.MoveTowards(transform.position,transform.position + _dir,Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }
}
