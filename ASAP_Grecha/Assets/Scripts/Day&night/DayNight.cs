using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // using text mesh for the clock display

using UnityEngine.Rendering; // used to access the volume component

public class DayNight : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay; // Display Time
    public Volume ppv; // this is the post processing volume

    public float tick; // Increasing the tick, increases second rate
    public float seconds;
    public int days = 0;
    public int secCycle = 20;

    public bool activateLights; // checks if lights are on
    public GameObject[] lights; // all the lights we want on when its dark
    public SpriteRenderer[] redLight; // star sprites 
    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
        DisplayTime();

    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        if (seconds >= secCycle)
        {
            seconds = 0;
            days += 1;
        }
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick
        ControlPPV(); // changes post processing volume after calculation
    }

    public void ControlPPV() // used to adjust the post processing slider.
    {
        if (days % 2 == 0)
        {
            ppv.weight = (float)seconds / secCycle;
            if (activateLights == false) // if lights havent been turned on
            {
                if (seconds > secCycle * 5 / 6) // wait until pretty dark
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // turn them all on
                    }
                    activateLights = true;
                }
            }
        }
        else
        {
            ppv.weight = 1 - (float)seconds / secCycle;
            if (activateLights == true) // if lights are on
            {
                if (seconds > secCycle * 2 / 6) // wait until pretty bright
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // shut them off
                    }
                    activateLights = false;
                }
            }
        }
    }

    public void DisplayTime() // Shows time and day in ui
    {
        timeDisplay.text = string.Format("{0:0}", seconds); // The formatting ensures that there will always be 0's in empty spaces
    }
}
