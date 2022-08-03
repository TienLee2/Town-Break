using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiHeli : MonoBehaviour
{

    public AudioSource Heli1;
    public AudioSource Heli2;

    void Start()
    {
        if (Random.Range(1, 3) == 2)
        {
            if (Random.Range(1, 3) == 2)
            {
                Heli1.Play();
            }
            else
            {
                Heli2.Play();
            }
        }
    }
}
