using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Timer timer = null;
    Text countdownText = null;

    private int totalCounts = 3;
    private int countsPassed = 0;
    public float countTime = 0.5f;
    public Image blockingImage;

    private void Awake()
    {
        countdownText = GetComponent<Text>();
    }

    public void StartCountdown()
    {
        StartCoroutine(CountdownOneSecond());
    }

    IEnumerator CountdownOneSecond()
    {
        countdownText.enabled = true;
        blockingImage.enabled = true;
        countdownText.text = "READY?";
        while(countsPassed < totalCounts){
            yield return new WaitForSeconds(countTime);
            countsPassed++;
            switch (countsPassed)
            {
                case 1:
                    countdownText.text = "SET";
                    break;
                case 2:
                    countdownText.text = "CLEAN!";
                    break;
                case 3:
                    countdownText.enabled = false;
                    blockingImage.enabled = false;
                    timer.StartTimer();
                    //start game
                    break;
            }
        }
    }
}
