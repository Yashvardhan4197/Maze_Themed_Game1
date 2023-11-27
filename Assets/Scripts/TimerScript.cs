using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI HighText;
    private bool timeisRunning;
    private float timeremaining;
    private float highscore=0;
    // Start is called before the first frame update
    void Start()
    {
        timeisRunning=true;
        highscore=PlayerPrefs.GetFloat("HighScore",0f);
        displayhigh(highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeisRunning)
        {
            if(timeremaining>=0){
                timeremaining+=Time.deltaTime;
                display(timeremaining);
            }

            if(timeremaining>highscore){
                highscore=timeremaining;
                PlayerPrefs.SetFloat("HighScore",highscore);
                PlayerPrefs.Save();
                displayhigh(highscore);
            }
        }
    }

    private void display(float timetoDisplay)
    {
        timetoDisplay+=1;
        float minutes=Mathf.FloorToInt(timetoDisplay/60);
        float seconds=Mathf.FloorToInt(timetoDisplay%60);
        text.text=string.Format("{0:00}:{1:00}",minutes,seconds);
    }
    private void displayhigh(float timetoDisplay)
    {
        timetoDisplay+=1;
        float minutes=Mathf.FloorToInt(timetoDisplay/60);
        float seconds=Mathf.FloorToInt(timetoDisplay%60);
        HighText.text=string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
