using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer1 : MonoBehaviour
{
    public TextMeshProUGUI textctd;
    public int secondsLeft = 30;
    public bool removingTime = false;


    void Start()
    {
        textctd.text = "00" + secondsLeft;
    }

     void Update()
    {
        if (removingTime == false && secondsLeft > 0)
        {
            StartCoroutine(TimerEvent());
        }
    }

    IEnumerator TimerEvent()
    {
        removingTime = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textctd.text = "00:0" + secondsLeft;
        }
        else
        {
            textctd.text = "00" + secondsLeft;
        }
        removingTime = false;
    }
}
