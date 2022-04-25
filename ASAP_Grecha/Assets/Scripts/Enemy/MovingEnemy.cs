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
    private LayerMask _layerMask;

    private bool _playerInZoneAttack;
    private bool _isAttack =true;

    public Totem Totem;
    public Hero Hero;

    public SpawnerController SpawnerController;
    public static MovingEnemy InstanceEnemy { get; set; }

    private Vector3 _dir;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _dir = Vector3.zero;
        _rb = transform.GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreLayerCollision(6,7);
    }
    void Update()
    {
        Move(); 
        if (InstanceEnemy == null)//??
        {
            InstanceEnemy = this;
        }
        AttackOfEnemy();


    }
    private void Move()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 5f);

        List<GameObject> list = collider.ToList().ConvertAll(b => b.gameObject);
        if (list.Contains(Hero.Instance.gameObject))
        {
            _dir = Hero.Instance.transform.position - transform.position;//fix
            _dir.y = 0;
            _dir.z = -0.10f;
            _rb.velocity = _dir.normalized * _speedEnemy;
        }
        else
        {
            _dir = Totem.transform.position - transform.position;
            _dir.y = 0;
            _dir.z = -0.10f;
            _rb.velocity = _dir.normalized * _speedEnemy;
        }
       
        if ( _rb.velocity.x > 0 && _facingRight)
        {
            Flip();
        }
        if (_rb.velocity.x < 0 && !_facingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            
        }
    } */
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
    private void AttackOfEnemy()
    {
        Vector2 velocity;
        if (_facingRight)
        {
            velocity = new Vector2(-1, 0);
        }
        else
        {
            velocity = new Vector2(1, 0);
        }
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition =  velocity;
        RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll(currentPosition,newPosition,3,_layerMask);

        List<GameObject> listHits = raycastHit2D.ToList().ConvertAll(b => b.collider.gameObject);
        Debug.DrawRay(currentPosition, newPosition, Color.red);

        if (listHits.Contains(Hero.Instance.gameObject) && _isAttack)
        {
            _playerInZoneAttack = true;
            _isAttack = false;
            StartCoroutine(DelayAttack());
            Debug.Log("1");
        }
    }
    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(1);
        if (_playerInZoneAttack)
        {
            Hero.Instance.GetDamage(_damageEnemy);
        }
        _isAttack=true; 
        Debug.Log("2");

    }



}
