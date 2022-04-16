using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] 
    private float _speed = 3f;
    [SerializeField]
    private int _lives = 5;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private Transform _firePoint;
     
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded = false;
    private bool _facingRight = false;
    public static Hero Instance { get; set; }
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject); 
        }
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    private void FixedUpdate()
    {
        CheckGround(); 
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    private void Run()
    {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"),0f ,0f);
        transform.position = transform.position + horizontal *  10f * Time.deltaTime;
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
        _firePoint.transform.Rotate(0f, 180f, 0f);

    }
    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);
        _isGrounded = collider.Length > 1;
    }

    public override void GetDamage()
    {
        if (_lives > 0)
        {
            _lives -= 1;
        }
        else
        {
            Die();
        }
        Debug.Log(_lives);
    }

}
