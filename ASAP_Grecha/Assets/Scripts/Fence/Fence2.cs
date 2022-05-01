using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fence2 : Entity
{
    public int liveFence;
    public int liveFenceMax;
    public static Fence2 InstanceFense2 { get; set; }

    public SpriteRenderer fence2;
    public Sprite qpriteImage11;
    public Sprite qpriteImage22;
    public Sprite qpriteImage33;
    private void Start()
    {
        liveFenceMax = liveFence;
        fence2 = GetComponent<SpriteRenderer>();
        fence2.sprite = qpriteImage11;
    }
    void Update()
    {
        if (liveFence <= liveFenceMax * 0.333f)
        {
            fence2.sprite = qpriteImage33;
        }
        else if (liveFence <= liveFenceMax * 0.666f)
        {
            fence2.sprite = qpriteImage22;
        }
        else
        {
            fence2.sprite = qpriteImage11;
        }
        if (InstanceFense2 == null)//??
        {
            InstanceFense2 = this;
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


