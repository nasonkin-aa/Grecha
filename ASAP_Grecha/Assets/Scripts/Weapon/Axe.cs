using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private Rigidbody2D _rb;
    public float _damageAxe ;
    private Collider2D[] collider;
    /* [SerializeField]
     private MovingEnemy _movingEnemy;*/

    void Start()
    {
        Vector2 _mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _derection = _mousPos - new Vector2(transform.position.x, transform.position.y);
        _rb.velocity = _derection.normalized * _speed;
    }
    void Update()
    {
        OnAxeEnter();
        transform.Rotate(0, 0, -1000f * Time.deltaTime);
    }
    private void OnAxeEnter()
    { 
        collider = Physics2D.OverlapCircleAll(transform.position, 0.7f);
        
        foreach (Collider2D a in collider)
        {
            if (a.transform.GetComponent<MovingEnemy>())
            {
                a.transform.GetComponent<MovingEnemy>().GetDamage(_damageAxe);
                Destroy(gameObject);
                break;
            }
        }
    }

    public void increasDamage(float attack)
    {
        _damageAxe *= attack;
    }
  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<MovingEnemy>())
        {
            Destroy(gameObject);
            foreach (Collider2D a in collider)
            {
                a.transform.GetComponent<MovingEnemy>().GetDamage(_damageAxe);
                break;
            }
        }
    }*/

}
