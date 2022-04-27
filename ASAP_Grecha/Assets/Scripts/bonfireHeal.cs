using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonfireHeal : MonoBehaviour
{
    bool healFlagEnter = false;
    bool healFlagDelay = true;
    public Collider2D other;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        healFlagEnter = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        healFlagEnter = false;
    }
    private void HealDelay()
    {
        healFlagDelay = true;
    }

    private void Update()
    {
        if (healFlagEnter && healFlagDelay && Hero.Instance._livesHero < Hero.Instance._maxLivesHero)
        {
            healFlagDelay = false;
            Hero.Instance._livesHero += 1;
            Debug.Log("Hp: " + Hero.Instance._livesHero);
            Invoke("HealDelay", 2f);
            DamagePopup.Create(Hero.Instance.transform.localPosition, 1);
        }
    }

    

}
