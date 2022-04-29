using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHud : MonoBehaviour
{
    private TMPro.TextMeshPro HP;
    private TMPro.TextMeshPro SOUL;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Awake()
    {
        HP = transform.Find("HP").GetComponent<TMPro.TextMeshPro>();
        SOUL = transform.Find("SOUL").GetComponent<TMPro.TextMeshPro>();
    }
    void Update()
    {
        HP.SetText(Hero.Instance._livesHero.ToString() + "/" + Hero.Instance._maxLivesHero.ToString());
        SOUL.SetText(Hero.Instance.soulCount.ToString() +"/" + Hero.Instance.soulCountMax.ToString());
    }
}
