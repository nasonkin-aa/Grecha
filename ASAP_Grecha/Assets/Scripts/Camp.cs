using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camp : Entity
{
    public int liveCamp;
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
        DamagePopup.Create(transform.localPosition, (int)damage);
        if (liveCamp > 0)
        {
            liveCamp -= (int)damage;
        }
        if (liveCamp <= 0)
        {
            Die();
            SceneManager.LoadScene(2);
        }
        Debug.Log(liveCamp);
    }
}
