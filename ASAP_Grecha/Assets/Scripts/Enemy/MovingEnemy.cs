using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Entity
{
    [SerializeField]
    private float _speedEnemy = 4f;
    [SerializeField]
    private float _liveEnemy = 100f;
    [SerializeField]
    private float _damageEnemy = 20f;
    public static MovingEnemy InstanceEnemy { get; set; }

    private Vector3 _dir;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _dir = transform.right;
        if (InstanceEnemy == null)
        {
            InstanceEnemy = this;
        }
        else if (InstanceEnemy == this)
        {
            Destroy(gameObject);
        }

    }
 
    void Update()
    {
        Move(); 
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
            Hero.Instance.GetDamage(_damageEnemy);
            
        }
    }
    public override void GetDamage(float damage)
    {
        if (_liveEnemy > 0)
        {
            _liveEnemy -= damage;
        }
        else if(_liveEnemy <= 0)
        {
            Die();
        }
        Debug.Log(_liveEnemy);
    }



}
