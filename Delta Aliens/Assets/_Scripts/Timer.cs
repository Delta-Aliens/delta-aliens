using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 0;
    public float endGameTime = 10;
    [SerializeField] private TMP_Text timeText;
 
    // Update is called once per frame
    void Update()
    {
        if (CheckEndGame()) {
            EventSystemsManager.Instance.EndGame();
        } else {       
            timeValue += Time.deltaTime;
            DisplayTime(timeValue);
        }
    }

    void DisplayTime(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    bool CheckEndGame() {
        if (timeValue >= 300) { 
            return true;
        }
        return false;
    }
}
