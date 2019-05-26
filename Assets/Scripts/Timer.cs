using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float roundTime = 0;
    private float time = 0;
    public Text timerText = null;
    public Text complementaryText = null;

    public RoundManager roundManager = null;

    private bool timerActive = false;

    public void StartTimer()
    {
        timerText.enabled = true;
        complementaryText.enabled = true;
        time = 30;
        ToggleTimer(true);
    }

    public void ToggleTimer(bool forceStart = false)
    {
        if (forceStart) timerActive = true;
        else timerActive = !timerActive;
    }

    private void Update()
    {
        if (timerActive)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timerText.text = (Mathf.Round(time * 10) / 10).ToString();
            }
            else
            {
                timerText.text = "0";
                roundManager.EndRound();
                ToggleTimer();
            }
        }
    }

    public void EndTimer()
    {
        time = 0;
    }
}
