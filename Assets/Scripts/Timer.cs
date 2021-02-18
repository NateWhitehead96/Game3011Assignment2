using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float minutes;
    public float seconds;
    public bool isTiming = true;

    // Update is called once per frame
    void Update()
    {
        if (isTiming)
        {
            if (seconds <= 0)
            {
                minutes--;
                seconds = 60;
            }

            seconds -= 1 * Time.deltaTime;

            timer.text = minutes.ToString() + " : " + seconds.ToString();

            if (minutes <= 0 && seconds <= 0)
            {
                print("gameover");
            }
        }
    }
}
