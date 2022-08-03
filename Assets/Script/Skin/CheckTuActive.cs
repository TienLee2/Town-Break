using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTuActive : MonoBehaviour
{
    public Transform parent;
    public GameObject defaultG;
    public int count = 0;

    public void Start()
    {
        Invoke("Skin", 0.1f);
        
    }

    void Skin()
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.active == true)
            {
                count++;
            }
        }



        if (count != 0)
        {

            defaultG.SetActive(false);
        }
    }
}
