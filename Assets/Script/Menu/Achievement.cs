using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievement : MonoBehaviour
{
    private static float score, time, ruby;

    public TextMeshProUGUI scoreText, timeText, rubyText;

    void Start()
    {
        score = PlayerPrefs.GetFloat("Score", 0);
        time = PlayerPrefs.GetFloat("Time", 0);
        ruby = PlayerPrefs.GetFloat("Ruby", 0);

        DisplayScore();
        DisplayTime();
        DisplayRuby();
    }

    public static float GetScore()
    {
        return score;
    }
    public static float GetTime()
    {
        return time;
    }
    public static float GetRuby()
    {
        return ruby;
    }

    public static void SetScore(float scoreToSet)
    {
        score = scoreToSet;
        PlayerPrefs.SetFloat("Score", score);
    }
    public static void SetTime(float timeToSet)
    {
        time = timeToSet;
        PlayerPrefs.SetFloat("Time", time);
    }
    public static void SetRuby(float rubyToSet)
    {
        ruby = rubyToSet;
        PlayerPrefs.SetFloat("Ruby", ruby);
    }

    public void DisplayScore()
    {
        scoreText.text = score.ToString();
    }
    public void DisplayTime()
    {
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("f0");

        
        timeText.text = minutes + "m" + " " + seconds + "s";
    }
    public void DisplayRuby()
    {
        rubyText.text = ruby.ToString();
    }
}
