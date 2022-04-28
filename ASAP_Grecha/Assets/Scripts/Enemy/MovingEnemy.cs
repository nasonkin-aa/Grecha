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
    [SerializeField]
    private enum TypeEnemy
    {
        wolf, Bird
    }
    [SerializeField]
    private TypeEnemy typeEnemy;

    public Material matBlink;
    public Material matDefault;
    

    private List<GameObject> listHits;
    private bool _playerInZoneAttack;
    private bool _isAttack = true;
    public GameObject lootDrop;

    public Totem Totem;
    public Hero Hero;
    public Animator animator;
    public Camp Camp;

    public SpawnerController SpawnerController;
    public static MovingEnemy InstanceEnemy { get; set; }

    private Vector3 _dir;
    private Rigidbody2D _rb;
    public SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent <SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = _spriteRenderer.material;
        _dir = Vector3.zero;
        _rb = transform.GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreLayerCollision(6,7);
    }
    void Update()
    {
        if (InstanceEnemy == null)//??
        {
            InstanceEnemy = this;
        }
        switch (typeEnemy)
        {

            case TypeEnemy.wolf:
                animator.SetBool("IsAttack", !_isAttack);
                MoveWolf();
                AttackOfEnemy();
                break;
            case TypeEnemy.Bird:
                MoveBird();
                break;
        }

    }
    private void MoveBird()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 2.5f);

        List<GameObject> list = collider.ToList().ConvertAll(b => b.gameObject);
        if (list.Contains(Camp.transform.gameObject))
        {
            _dir = Camp.transform.position - transform.position;
            //_dir.y = 0;
            _dir.z = -0.10f;
            _rb.velocity = _dir.normalized * _speedEnemy;
        }
        else
        {
            _dir = Totem.transform.position - transform.position;//fix
            _dir.y = 0;
            _dir.z = -0.10f;
            _rb.velocity = _dir.normalized * _speedEnemy;
        }
        CheckeFlipp();
    }
    private void MoveWolf()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 5f);

        List<GameObject> list = collider.ToList().ConvertAll(b => b.gameObject);
        if (list.Contains(Hero.Instance.gameObject))
        {
            _dir = Hero.Instance.transform.position - transform.position;//fix
            _dir.y = 0;
            _dir.z = -1;
            _rb.velocity = _dir.normalized * _speedEnemy;
        }
        else
        {
            _dir = Totem.transform.position - transform.position;
            _dir.y = 0;
            _dir.z = -1f;
            _rb.velocity = _dir.normalized * _speedEnemy;
        }

        CheckeFlipp(); 
    }
    private void CheckeFlipp()
    {
        if (_rb.velocity.x > 0 && _facingRight)
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
        _spriteRenderer.material = matBlink;
        if (_liveEnemy > 0)
        {
            Invoke("ResetMaterial", .2f);
            _liveEnemy -= damage;
            DamagePopup.Create(transform.localPosition, (int) damage);
        } 
        if(_liveEnemy <= 0)
        {
            SpawnerController.DethEmemy--;
            Debug.Log(SpawnerController.DethEmemy);
            Die();
             
            Instantiate(lootDrop, new Vector3(Random.Range(transform.localPosition.x + 1, transform.localPosition.x - 1),transform.localPosition.y,0), Quaternion.identity);
        }
        Debug.Log(_liveEnemy);
    }

    void ResetMaterial()
    {
        _spriteRenderer.material = matDefault;
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
        RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll(currentPosition,newPosition,2.3f,_layerMask);

        listHits = raycastHit2D.ToList().ConvertAll(b => b.collider.gameObject);
        Debug.DrawRay(currentPosition, newPosition * 2.3f, Color.red);

        if (listHits.Contains(Hero.Instance.gameObject) && _isAttack)
        {
            //_playerInZoneAttack = true;
            _isAttack = false;
            Debug.Log("1");
        }
    }
  
    public void PlayerInZoneAttack()
    {
        if (listHits.Contains(Hero.Instance.gameObject))
        {
            DamagePopup.Create(Hero.Instance.transform.localPosition, (int)_damageEnemy);
            Hero.Instance.GetDamage(_damageEnemy);
        }
        // if (_playerInZoneAttack)
        _isAttack = true;
        Debug.Log("2");

    }



}
