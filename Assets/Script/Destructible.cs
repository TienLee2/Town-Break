using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    private int score;
    public GameObject[] Explosion;
    private int yes;

    private int bu;
    private int te;
    public List<GameObject> Buffs = new List<GameObject>();

    void Start()
    {
        Buffs.AddRange(GameObject.FindGameObjectsWithTag("Buff"));
        bu = Random.Range(0, 5);
        te = Random.Range(0, 5);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Des", 0.6f);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            Des();
        }


    }
    
    void Des()
    {
        score = Random.Range(30, 50);
        SumScore.Add(score);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
        yes= Random.Range(0, Explosion.Length);
        Instantiate(Explosion[yes], transform.position, transform.rotation);
        
        
        if(bu == 2)
        {
            if (te == 0)
            {
                Instantiate(Buffs[0], transform.position, transform.rotation);
            }
            if (te == 1)
            {
                Instantiate(Buffs[1], transform.position, transform.rotation);
            }
            if (te == 2)
            {
                Instantiate(Buffs[2], transform.position, transform.rotation);
            }
            if (te == 3)
            {
                Instantiate(Buffs[3], transform.position, transform.rotation);
            }
            if (te == 4)
            {
                Instantiate(Buffs[4], transform.position, transform.rotation);
            }


        }

    }
}
