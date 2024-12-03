using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    public GameEnding gameEnding;

    bool m_IsGameClear = false;

    // Update is called once per frame
    void Update()
    {
        if (!m_IsGameClear)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 10)
                {
                    timerText.color = Color.red;
                }
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                gameEnding.TimerDone();
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = string.Empty; // Clear the text
            timerText.enabled = false;
        }
    }

    public void Clear()
    {
        m_IsGameClear = true;
    }
}
