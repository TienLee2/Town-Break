using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hit;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int dam = Random.Range(10, 20);
            HealthSystem.Instance.TakeDamage(dam);
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else 
        {
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
