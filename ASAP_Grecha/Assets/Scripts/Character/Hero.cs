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
     
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded = false;
    private bool _facingRight = true;
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
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

        if (dir.x > 0f && _facingRight)
        {
            Flip();
        }
        if (dir.x < 0f && !_facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);

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
