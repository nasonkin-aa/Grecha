using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hero : Entity
{
    [SerializeField] 
    private float _speed = 0f;
    [SerializeField]
    public float _livesHero;
    [SerializeField]
    public float _maxLivesHero;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    public int soulCount;
    [SerializeField]
    public int soulCountMax;
    [SerializeField]
    public BoxCollider2D coliderJump;
    [SerializeField]
    public LayerMask layer;
    public CameraController cameraController;

    private Material matBlink;
    private Material matDefault;
    private Material matBlinkHeal;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded = false;
    private bool _facingRight = false;
    

    public static Hero Instance { get; set; }
    public Animator animator; 

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
    private void Start()
    {
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matBlinkHeal = Resources.Load("HealBlink", typeof(Material)) as Material;
        matDefault = _spriteRenderer.material;
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
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void FixedUpdate()
    {
         
    }
    private void Update()
    {
        CheckGround();
        if (_maxLivesHero < _livesHero) _livesHero = _maxLivesHero;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal"))); // ������� � �������� �������� ���������
        animator.SetBool("IsJumping", !_isGrounded); // ������� � ��������, ��������� �� �� �� �����������
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
        Vector3 a = transform.position;
        a.y -= 1.5f;
        Collider2D[] collider = Physics2D.OverlapCircleAll(a, 0.4f, layer);
        _isGrounded = collider.Length > 0;
    }
    public override void GetDamage(float damage)
    {
        _spriteRenderer.material = matBlink;
        cameraController.ShakeCamera();
        _livesHero -= damage;
        if (_livesHero > 0)
        {
            Invoke("ResetMaterial", .2f);
        }
        else
        {
            Die();
            SceneManager.LoadScene(2);
        }
        Debug.Log(_livesHero);
    }

    public void HealMaterrial()
    {
        _spriteRenderer.material = matBlinkHeal;
        Invoke("ResetMaterial", .1f);
    }
    void ResetMaterial()
    {
        _spriteRenderer.material = matDefault;
    }
}

