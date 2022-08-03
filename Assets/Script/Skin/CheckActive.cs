using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    public Transform parent;
    public GameObject defaultG;
    public int count = 0;

    public void Update()
    {
        if (count == 0)
        {
            foreach (Transform child in parent)
            {
                if (child.gameObject.active == true)
                {
                    count++;
                }
            }
            defaultG.SetActive(true);
        }

        if (count != 0)
        {
            foreach (Transform child in parent)
            {
                if (child.gameObject.active == false)
                {
                    count--;
                }

            }
            defaultG.SetActive(false);
        }
    }
}
