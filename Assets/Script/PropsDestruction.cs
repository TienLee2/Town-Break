using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsDestruction : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider mesh;
    private int score;
    

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        mesh = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            EnableGravity();
            Invoke("Delete", 5f);
            score = Random.Range(2, 10);
            SumScore.Add(score);
        }
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
    public void EnableGravity()
    {
        mesh.isTrigger = false;
        rb.useGravity = true;
        
    }
}
