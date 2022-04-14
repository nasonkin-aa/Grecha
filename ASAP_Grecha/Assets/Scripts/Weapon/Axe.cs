using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private Rigidbody2D _rb;
    void Start()
    {
        _rb.velocity = transform.right * _speed;
    }
    void Update()
    {
        transform.Rotate(0, 0, -1000f * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<MovingEnemy>())
        {
            Destroy(collision.gameObject);
        }
    }
}
