using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fence : Entity
{
    public int liveFence;
    public int liveFenceMax;
    public static Fence InstanceFense { get; set; }

    public SpriteRenderer fence;
    public Sprite qpriteImage1;
    public Sprite qpriteImage2;
    public Sprite qpriteImage3;


    private void Start()
    {
        liveFenceMax = liveFence;
        fence = GetComponent<SpriteRenderer>();
        fence.sprite = qpriteImage1;
    }
    void Update()
    {
        if (liveFence <= liveFenceMax * 0.333f)
        {
            fence.sprite = qpriteImage3;
        }
        else if (liveFence <= liveFenceMax * 0.666f)
        {
            fence.sprite = qpriteImage2;
        }
        else
        {
            fence.sprite = qpriteImage1;
        }
        if (InstanceFense == null)//??
        {
            InstanceFense = this;
        }
        if (liveFenceMax < liveFence)
        {
            liveFenceMax = liveFence;
        }
    }
    public override void GetDamage(float damage)
    { 
        if (liveFence > 0)
        {
            liveFence -= (int)damage;
            DamagePopup.Create(transform.localPosition, (int)damage);

        }
        if (liveFence <= 0)
        {
            Die();
        }
        Debug.Log(liveFence);
    }
}

