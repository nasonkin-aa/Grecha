using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDropTotemTrigger : MonoBehaviour
{
    private bool isTrigger = false;
    public updateSoulRemain updateSoulRemain;
    public Animator animUI;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hero.Instance.gameObject == collision.gameObject)
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Hero.Instance.gameObject == collision.gameObject)
        {
            isTrigger = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTrigger)
        {
            updateSoulRemain.countUpgrade += Hero.Instance.soulCount;
            Hero.Instance.soulCount = 0;
            if (updateSoulRemain.remainToUpgrade <= updateSoulRemain.countUpgrade)
            {
                animUI.SetBool("IsUITreeOn", true);
                updateSoulRemain.countUpgrade -= updateSoulRemain.remainToUpgrade;
                updateSoulRemain.remainToUpgrade += 15;
                Invoke("GamePause", 0.3f);
            }
        }
        
    }

    private void GamePause()
    {
        Time.timeScale = 0f;
    }
}
