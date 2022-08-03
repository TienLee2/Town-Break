using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private GameObject player;
    private ShootingSystem turret;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Turret");
        turret = player.GetComponent<ShootingSystem>();
    }

    void Update()
    {
        transform.RotateAround(gameObject.transform.position, Vector3.up, 45 * Time.deltaTime);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turret.fireDelay = turret.fireDelay - 0.03f;
            turret.ammoDamage = turret.ammoDamage + 3f;
            Destroy(gameObject);
        }
    }
}
