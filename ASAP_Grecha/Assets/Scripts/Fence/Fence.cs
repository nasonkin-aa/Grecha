using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : Entity
{
    public int liveFence = 300;
    public static Fence InstanceFense { get; set; }
    private void Start()
    {
        
    }
    void Update()
    {
        if (InstanceFense == null)//??
        {
            InstanceFense = this;
        }

    }
    public override void GetDamage(float damage)
    {
        if (liveFence > 0)
        {
            liveFence -= (int)damage;
        }
        if (liveFence <= 0)
        {
            Die();
        }
        Debug.Log(liveFence);
    }
}

