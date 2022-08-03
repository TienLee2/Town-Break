using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTime : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject con;
    
    public GameObject final;
    public Animation anim;

    private Movement movement;
    private die Die;
    private HealthSystem Health;

    public GameObject move;
    public GameObject dies;
    public GameObject health;

    public bool ContinueOne = false;
    public int lives = 1;
    public int Active = 0;

    public void Start()
    {
        Health = health.GetComponent<HealthSystem>();
        Die = dies.GetComponent<die>();
        movement = move.GetComponent<Movement>();

        Time.timeScale = 0;
        con.SetActive(true);

        if (ContinueOne == false && lives == 1)
        {
            StartCoroutine("CountDownToStart");
        }
    }


    IEnumerator CountDownToStart()
    {
        Debug.Log("Active Countdown");

        while (countdownTime != 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            
            yield return new WaitForSecondsRealtime(1f);
            
            countdownTime--;
            
        }
        
        if (countdownTime <= 0 && lives == 1 || countdownTime <= 0 && ContinueOne == false)
        {
            Diere();
        }
    }
    
    void Update()
    {
        if (ContinueOne == true && lives == 1)
        {
            StopCoroutine("CountDownToStart");
            this.enabled = false;
            lives = 0;
        }
        if (Health.hitPoint <= 0 && Active > 1)
        {
            Invoke("Diere", 2f);
        }
    }
    public void WatchAdAndRevive()
    {
        StopCoroutine("CountDownToStart");
        Time.timeScale = 1;
        ContinueOne = true;
        movement.Revive = true;
        Health.hitPoint = Health.maxHitPoint;
        Die.Revive = true;
    }
    
    public void TimeBack()
    {
        Time.timeScale = 1;
    }

    public void Diere()
    {
        con.SetActive(false);
        SumScore.SaveHighScore();
        final.SetActive(true);
        anim.Play("New Animation");
    }


    
}
