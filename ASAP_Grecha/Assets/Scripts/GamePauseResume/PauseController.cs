using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    bool IsGamePlay = true;
    private TMPro.TextMeshPro PAUSE;
    private void Awake()
    {
        PAUSE = transform.Find("PAUSE").GetComponent<TMPro.TextMeshPro>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePlay)
            {
                Time.timeScale = 0f;
                IsGamePlay = false;
                PAUSE.SetText("=");
            }
            else
            {
                Time.timeScale = 1f;
                IsGamePlay = true;
                PAUSE.SetText("");
            }
        }
    }
    
}
