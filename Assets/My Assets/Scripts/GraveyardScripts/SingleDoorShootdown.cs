using UnityEngine;
using System.Collections;

public class SingleDoorShootdown : MonoBehaviour {

    Animator animator;
    int doorHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorHealth = 100;

    }

    void Update()
    {
        if (doorHealth <= 0)
        {
            animator.SetBool("OpenAndBreak", true);
            animator.SetBool("FalldownIdle", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && doorHealth > 0)
        {
            doorHealth -= 10;
            Debug.Log("DoorHealth " + doorHealth);
        }
    }
}
