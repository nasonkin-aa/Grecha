using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonfireHeal : MonoBehaviour
{
    bool healFlagEnter = false;
    bool healFlagDelay = true;
    public int firstRange;
    public int lastRange;
    int healCount;
    public Collider2D other;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hero.Instance.gameObject == collision.gameObject) healFlagEnter = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Hero.Instance.gameObject == collision.gameObject) healFlagEnter = false;
    }
    private void HealDelay()
    {
        healFlagDelay = true;
    }

    private void Update()
    {
        healCount = Random.Range(firstRange, lastRange);
        if (healFlagEnter && healFlagDelay && Hero.Instance._livesHero < Hero.Instance._maxLivesHero)
        {
            healFlagDelay = false;
            Hero.Instance._livesHero += healCount;
            Hero.Instance.HealMaterrial();
            Debug.Log("Hp: " + Hero.Instance._livesHero);
            Invoke("HealDelay", 1f);
        }
    }

    

}
