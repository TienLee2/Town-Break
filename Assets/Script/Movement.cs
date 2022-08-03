using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float radius = 10f;
   
    public Joystick joystick;
    private Rigidbody m_Rb;
    public Animator animator;

    public GameObject health;
    private HealthSystem yes;

    public bool Moving = true;
    public bool Die = false;
    public bool Revive = false;

    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        yes = health.GetComponent<HealthSystem>();
        speed = speed + Upgrade.GetSpeed();
    }

    void Back()
    {
        Revive = false;
        Moving = true;
        animator.SetInteger("Die", 0);
    }

    void FixedUpdate()
    {
        if (yes.hitPoint <= 0 && Die == false)
        {
            Moving = false;
            animator.SetInteger("Die", 1);
            animator.SetBool("isMoving", false);
            animator.SetInteger("Action", 0);
            Die = true;
        }

        if (Revive)
        {
            animator.SetInteger("Die", 2);
            Die = false;
            Invoke("Back", 1);
        }

        if (Moving)
        {
            float horizontalInput = joystick.Horizontal;
            float verticalInput = joystick.Vertical;

            if (horizontalInput != 0 || verticalInput != 0)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }


            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
            if (movement == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(movement);

            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

            Vector3 rotatedMovement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement;

            m_Rb.MovePosition(m_Rb.position + rotatedMovement * speed * Time.fixedDeltaTime);
            m_Rb.MoveRotation(targetRotation);
        }
        if (!Moving)
            return;

       
    }


    
    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Building"))
            {
                int randomInt = Random.Range(0, 3);

                if (randomInt == 0)
                {
                    animator.SetInteger("Action", 1);
                    Invoke("Stop", 1.05f);
                }
                if (randomInt == 1)
                {
                    animator.SetInteger("Action", 2);
                    Invoke("Stop", 1.15f);
                }
                if (randomInt == 2)
                {
                    animator.SetInteger("Action", 3);
                    Invoke("Stop", 1.05f);
                }
                animator.SetBool("isMoving", false);
                Moving = false;
                animator.SetBool("isMoving", false);
                Moving = false;
            }
    }
 

    void Stop()
    {
        
        animator.SetInteger("Action", 0);
        Moving = true;
        
    }
}