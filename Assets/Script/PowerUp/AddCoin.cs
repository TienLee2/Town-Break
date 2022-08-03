using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoin : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(gameObject.transform.position, Vector3.up, 45 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Wallet.SetAmount(Wallet.GetAmount() + 1);

            Destroy(gameObject);
        }
    }
}
