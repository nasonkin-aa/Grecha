using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovingEnemy : Entity
{
    [SerializeField]
    public float _speedEnemyWolf = 0f;
    [SerializeField]
    public float _speedEnemyBird = 0f;
    [SerializeField]
    public float _liveEnemy;
    [SerializeField]
    private float _damageEnemy = 15f;
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
    public Fence fence;

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
                animator.SetBool("IsAttack", !_isAttack);
                AttackOfEnemy();
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
            _rb.velocity = _dir.normalized * (Random.Range(2, 4) + _speedEnemyBird);
        }
        else
        {
            _dir = Totem.transform.position - transform.position;//fix
            _dir.y = 0;
            _dir.z = -0.10f;
            _rb.velocity = _dir.normalized * (Random.Range(2, 4) + _speedEnemyBird);
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
            _rb.velocity = _dir.normalized * (Random.Range(2.6f, 3.6f) + _speedEnemyWolf);
        }
        else
        {
            _dir = Totem.transform.position - transform.position;
            _dir.y = 0;
            _dir.z = -1f;
            _rb.velocity = _dir.normalized * (Random.Range(2.6f, 3.6f) + _speedEnemyWolf);
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
            Invoke("LootDropDestroy", 5f);
        }
        Debug.Log(_liveEnemy);
    }

    void LootDropDestroy()
    {
        Destroy(gameObject);
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
        RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll(currentPosition,newPosition,Random.Range(1f,2f));

        listHits = raycastHit2D.ToList().ConvertAll(b => b.collider.gameObject);
        Debug.DrawRay(currentPosition, newPosition * 2.3f, Color.red);

        if (listHits.Contains(Hero.Instance.gameObject) && _isAttack || listHits.Contains(Fence.InstanceFense.gameObject) && _isAttack 
            || listHits.Contains(Fence2.InstanceFense2.gameObject) && _isAttack || listHits.Contains(Camp.Instance.gameObject) && _isAttack)
        {
            //_playerInZoneAttack = true;
           // _speedEnemy = 0;
            _isAttack = false;
            Debug.Log("1");
        }
    }
  
    public void PlayerInZoneAttack()
    {
        if (listHits.Contains(Hero.Instance.gameObject) )
        {
            DamagePopup.Create(Hero.Instance.transform.localPosition, (int)_damageEnemy);
            Hero.Instance.GetDamage(_damageEnemy);
        }
        if (listHits.Contains(Fence.InstanceFense.gameObject))
            {
            Debug.Log("gav");
            Fence.InstanceFense.GetDamage(_damageEnemy);
        }
        if (listHits.Contains(Fence2.InstanceFense2.gameObject))
        {
            Debug.Log("gav");
            Fence2.InstanceFense2.GetDamage(_damageEnemy);
        }
        if (listHits.Contains(Camp.Instance.gameObject))
        {
            Debug.Log("gav");
            Camp.Instance.GetDamage(_damageEnemy);
        }
        // if (_playerInZoneAttack)
        _isAttack = true;
        Debug.Log("2");
       // _speedEnemy = 5;

    }



}
