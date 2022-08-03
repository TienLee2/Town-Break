using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public GameObject health;
    public GameObject turret;
    public GameObject move;

    private HealthSystem yes;
    private ShootingSystem shoot;
    private Movement movement;

    public GameObject panel;
    

    private CountDownTime countdown;

    public bool Revive = false;

    private int count,ct = 0;

    private float startTime, t;

    void Start()
    {
        yes = health.GetComponent<HealthSystem>();
        shoot = turret.GetComponent<ShootingSystem>();
        countdown = GetComponent<CountDownTime>();

        movement = move.GetComponent<Movement>();
        startTime = Time.time;
    }

    void Update()
    {
        if(yes.hitPoint <= 0)
        {
            movement.Moving = false;
            panel.SetActive(false);
            shoot.enabled = false;
            Invoke("Die", 2f);
        }

        if(Revive)
        {
            Invoke("Revives", 1);
        }
        t = Time.time - startTime;
    }

    void Revives()
    {
        panel.SetActive(true);
        shoot.enabled = true;
        Revive = false;
    }

    void Die()
    {
        countdown.enabled = true;
        if(count==0 || count ==1)
        {
            countdown.Active++;
            count++;
        }
        if(ct==0)
        {
            Achievement.SetTime(Achievement.GetTime() + t);
            ct = 1;
        }
    }
}
