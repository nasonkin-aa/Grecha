using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSoul : MonoBehaviour
{
    public enum PickupObject {SOUL};
    public PickupObject currentObject;
    public int pickupSomething = 69;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Hero.Instance.gameObject)
        {   
            if (currentObject == PickupObject.SOUL)
            {
                Debug.Log(Hero.Instance.soulCount);
                //Hero.heroStats.soulCount += pickupSomething;
                Hero.Instance.soulCount += pickupSomething;
                //Debug.Log(Hero.heroStats.soulCount);
            }
           Destroy(gameObject);
        }
    }
}
