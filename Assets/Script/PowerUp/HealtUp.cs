using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtUp : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(gameObject.transform.position, Vector3.up, 45 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthSystem.Instance.SetMaxHealth(20);
            HealthSystem.Instance.HealDamage(40);
            
            Destroy(gameObject);
        }
    }
}
