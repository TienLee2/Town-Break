using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject Girl, Girl1, bg;
    public GameObject[] Face;
    public GameObject health;

    private HealthSystem ye;
    private int popUpIndex;
    private int FaceIndex;
    bool yes = true;
    private int wait1, wait = 0;
    public void Start()
    {
        ye = health.GetComponent<HealthSystem>();
    }

    public void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        for (int f = 0; f < Face.Length; f++)
        {
            if (f == FaceIndex)
            {
                Face[f].SetActive(true);
            }
            else
            {
                Face[f].SetActive(false);
            }
        }

        switch(popUpIndex)
        {
            case 2:
                Face[3].SetActive(true);
                Face[0].SetActive(false);
                break;
            case 3:
                Face[2].SetActive(true);
                Face[0].SetActive(false);
                break;
            case 4:
                yes = false;
                popUps[4].SetActive(false);
                Girl.SetActive(false);
                bg.SetActive(false);
                if (SumScore.Score > 50)
                {
                    yes = true;
                    popUps[4].SetActive(true);
                    Girl.SetActive(true);
                    bg.SetActive(true);
                }
                break;
            case 5:
                Face[1].SetActive(true);
                Face[0].SetActive(false);
                break;
            case 6:
                yes = false;
                popUps[6].SetActive(false);
                Girl.SetActive(false);
                bg.SetActive(false);
                if (ye.maxHitPoint > 200f)
                {
                    yes = true;
                    popUps[6].SetActive(true);
                    Girl.SetActive(true);
                    bg.SetActive(true);
                    Face[1].SetActive(true);
                    Face[0].SetActive(false);
                }
                break;
            case 7:
                Face[2].SetActive(true);
                Face[0].SetActive(false);
                break;
            case 8:
                yes = false;
                popUps[8].SetActive(false);
                Girl.SetActive(false);
                bg.SetActive(false);

                StartCoroutine(TT1());
                if (wait == 1)
                {
                    yes = true;
                    popUps[8].SetActive(true);
                    Girl.SetActive(true);
                    bg.SetActive(true);
                    Face[2].SetActive(true);
                    Face[0].SetActive(false);
                }
                break;
            case 9:
                Girl.SetActive(false);
                Girl1.SetActive(true);
                break;
            case 10:
                yes = false;
                popUps[10].SetActive(false);
                Girl1.SetActive(false);
                bg.SetActive(false);

                StartCoroutine(TT());
                if (wait1 == 1)
                {
                    yes = true;
                    popUps[10].SetActive(true);
                    Girl.SetActive(true);
                    bg.SetActive(true);
                }
                break;
            case 11:
                yes = false;
                Face[2].SetActive(true);
                Face[0].SetActive(false);
                break;
        }
    }

    public void OnClick()
    {
        if(yes == true)
        {
            popUpIndex++;
        }
    }
    IEnumerator TT()
    {
        yield return new WaitForSeconds(4);
        wait1 = 1;
    }
    IEnumerator TT1()
    {
        yield return new WaitForSeconds(6);
        wait = 1;
    }
}
