using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [Header("Setup")]
    public Transform RocketTarget;
    public Rigidbody RocketRgb;

    public float turnSpeed = 1f;
    private float rocketFlySpeed = 10f;

    private Transform rocketLocalTrans;

    public GameObject hit;

    private int interval = 3;

    // Start is called before the first frame update
    void Start()
    {
        RocketTarget = GameObject.FindWithTag("Player").transform;
        rocketLocalTrans = GetComponent<Transform>();
        
        rocketFlySpeed = Random.Range(7f, 8f);
    }


    private void FixedUpdate()
    {
        if (Time.frameCount % interval == 0)
        {
            if (!RocketRgb) //If we have not set the Rigidbody, do nothing..
                return;

            RocketRgb.velocity = rocketLocalTrans.forward * rocketFlySpeed;

            //Now Turn the Rocket towards the Target
            var rocketTargetRot = Quaternion.LookRotation(RocketTarget.position - rocketLocalTrans.position);

            RocketRgb.MoveRotation(Quaternion.RotateTowards(rocketLocalTrans.rotation, rocketTargetRot, turnSpeed));
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody plRgb = collision.gameObject.GetComponent<Rigidbody>();
            if (plRgb)
                plRgb.AddForceAtPosition(Vector3.up * 1000f, plRgb.position);
            int dam = Random.Range(15, 25);
            HealthSystem.Instance.TakeDamage(dam);
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);

            //Deactivate Rocket..
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}