using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        
        Vector3 trans = new Vector3(0, 0, -1);
        DamagePopup.Create(trans, 500);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 trans = new Vector3(0, 0, -1);
            DamagePopup.Create(trans, 69);
        }
    }

}
