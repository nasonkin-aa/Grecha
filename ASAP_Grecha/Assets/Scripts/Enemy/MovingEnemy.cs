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
    [SerializeField]
    private bool _facingRight = false;

    public Totem Totem;
    public Hero Hero;

    public SpawnerController SpawnerController;
    public static MovingEnemy InstanceEnemy { get; set; }

    private Vector3 _dir;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _dir = transform.right;
    }
    void Update()
    {
        Move(); 
        if (InstanceEnemy == null)//??
        {
            InstanceEnemy = this;
        }
    }
    private void Move()
    {

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * _dir.x * 0.7f, 0.1f);
        transform.position = Vector3.MoveTowards(transform.position, Totem.transform.position, Time.deltaTime);
        if (horizontal.x > 0f && _facingRight)
        {
            Flip();
        }
        if (horizontal.x < 0f && !_facingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
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
        if(_liveEnemy <= 0)
        {
            SpawnerController.DethEmemy--;
            Debug.Log(SpawnerController.DethEmemy);
            Die();
        }
        Debug.Log(_liveEnemy);
    }
}
