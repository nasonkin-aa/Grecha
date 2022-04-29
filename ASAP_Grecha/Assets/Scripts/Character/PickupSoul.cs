using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSoul : MonoBehaviour
{
    public enum PickupObject {SOUL};
    public PickupObject currentObject;
    public int timeDieSoul;

    private void Update()
    {
        Destroy(gameObject, timeDieSoul);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Hero.Instance.gameObject && Hero.Instance.soulCount < Hero.Instance.soulCountMax)
        {   
            if (currentObject == PickupObject.SOUL)
            {
                Debug.Log(Hero.Instance.soulCount);
                //Hero.heroStats.soulCount += pickupSomething;
                Hero.Instance.soulCount += 1;
                //Debug.Log(Hero.heroStats.soulCount);
            }
           Destroy(gameObject);
        }
    }
}
