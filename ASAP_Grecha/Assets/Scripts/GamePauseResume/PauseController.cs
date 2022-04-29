using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    bool IsGamePlay = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePlay)
            {
                Time.timeScale = 0f;
                IsGamePlay = false;
            }
            else
            {
                Time.timeScale = 1f;
                IsGamePlay = true;
            }
        }
    }
}
