using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fence2 : Entity
{
    public int liveFence = 300;
    public static Fence2 InstanceFense2 { get; set; }
 
    void Update()
    {
        if (InstanceFense2 == null)//??
        {
            InstanceFense2 = this;
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


