using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateSoulRemain : MonoBehaviour
{
    private TMPro.TextMeshPro soulRemain;
    public int remainToUpgrade;
    public int countUpgrade;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Awake()
    {
        soulRemain = transform.Find("soulRemain").GetComponent<TMPro.TextMeshPro>();
        remainToUpgrade = 10;
        countUpgrade = 0;
    }
    void Update()
    {
        soulRemain.SetText(countUpgrade.ToString() + "/" + remainToUpgrade.ToString());
    }
}
