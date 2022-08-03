using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFire : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthSystem.Instance.TakeDamage(1.5f);
        }
      
    }
}
