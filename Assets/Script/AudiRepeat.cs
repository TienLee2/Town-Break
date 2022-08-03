using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiRepeat : MonoBehaviour
{
    public AudioSource police;

    void Start()
    {
        float S = Random.Range(10f, 20f);
        float R = Random.Range(40f, 70f);
        InvokeRepeating("Horn", S, R);
    }

   void Horn()
    {
        police.Play();
    }
}
