using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovingEnemy : Entity
{
    [SerializeField]
    private float _speedEnemy = 5f;
    [SerializeField]
    private float _liveEnemy = 100f;
    [SerializeField]
    private float _damageEnemy = 20f;
    [SerializeField]
    private bool _facingRight = false;
    [SerializeField]
    

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
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 5f);

        List<GameObject> list = collider.OfType<Collider2D>().ToList().ConvertAll(b => b.gameObject);
        if (list.Contains(Hero.Instance.gameObject))
        {
            transform.position = Vector2.MoveTowards(transform.position, Hero.Instance.transform.position, _speedEnemy * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Totem.transform.position, _speedEnemy * Time.deltaTime);
        }
       
        if (transform.position.x < Totem.transform.position.x && _facingRight)
        {
            Debug.Log(transform.localPosition.normalized.x);
            Flip();
        }
        if (transform.position.x > Totem.transform.position.x  && !_facingRight)
        {
            Debug.Log(transform.localPosition.normalized.x);
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
