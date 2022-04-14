using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -1000f * Time.deltaTime);

    }
}
