using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject HighScore;
    public int score;
    
    public void Awake()
    {
        score = SumScore.Score;
        HighScore.SetActive(false);
    }
    public void Update()
    {
        if (score > Achievement.GetScore())
        {
            Achievement.SetScore(score);
            HighScore.SetActive(true);
        }
        
       
        scoreText.text = score.ToString();
    }
    
}
