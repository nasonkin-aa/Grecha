using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : Entity
{
    public int liveCamp = 5;
    public static Camp Instance{ get; set; }
    private void Start()
    {

    }
    void Update()
    {
        if (Instance == null)//??
        {
            Instance = this;
        }

    }
    public override void GetDamage(float damage)
    {
        if (liveCamp > 0)
        {
            liveCamp -= (int)damage;
        }
        if (liveCamp <= 0)
        {
            Die();
        }
        Debug.Log(liveCamp);
    }
}
