using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingTime;

    void Update()
    {
        if (remainingTime > 30)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 30 & remainingTime>10)
        {
            timerText.color = Color.yellow;
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 10)
        {
            timerText.color = Color.red;
            remainingTime -= Time.deltaTime;

            if(remainingTime < 0)
            {
              remainingTime = 0;
              FindObjectOfType<GameManager>().GameOver();
            }
            
            

        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        
    }
}