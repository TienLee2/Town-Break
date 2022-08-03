using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangeUp : MonoBehaviour
{
    private GameObject player;
    private GameObject cameras;

    private ShootingSystem turret;
    public TopDownCamera range;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Turret");
        cameras = GameObject.FindGameObjectWithTag("MainCamera");

        turret = player.GetComponent<ShootingSystem>();
        
        range = cameras.GetComponent<TopDownCamera>();
        
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
            turret.range = turret.range + 0.5f;

            range.position.distanceFromTarget = range.position.distanceFromTarget - 0.5f;
            

            Destroy(gameObject);
        }
    }
}
