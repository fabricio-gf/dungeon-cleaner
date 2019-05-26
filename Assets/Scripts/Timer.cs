using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public Text timerText = null;

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerText.text = (Mathf.Round(time * 100) / 100).ToString();
        }
        else
        {
            timerText.text = "0";
        }
    }
}
