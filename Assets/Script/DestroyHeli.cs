using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeli : MonoBehaviour
{
    
    public GameObject des;
    public Transform desPosition;
    public GameObject Explosion;
    // Update is called once per frame
    void Update()
    {
        if(des == null)
        {
            Destroy(gameObject);
            Instantiate(Explosion, desPosition.position, desPosition.rotation);
        }
    }
}
