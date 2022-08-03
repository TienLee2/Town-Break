using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUp : MonoBehaviour
{
    private GameObject player;
    private Movement move;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        move = player.GetComponent<Movement>();
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
            move.speed = move.speed + 0.3f;
            Destroy(gameObject);
        }
    }
}
