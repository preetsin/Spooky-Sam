using UnityEngine;
using System.Collections;

public class GhoulNav : MonoBehaviour
{

    public Transform[] targetDestinations;
    NavMeshAgent agent;
    Animator animator;
    bool hasTarget;
    int targetId;
    RaycastHit objectHit;
    public Transform player;
    public bool trapped;
    Vector3 fwd;
    bool inRange;
    bool hasSpoke = false;
    void Start() {
        hasTarget = false;
        inRange = false;
        animator = GetComponent<Animator>();
        targetId = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetDestinations[targetId].position;
        animator.SetBool("IsWalking", true);
        
        
    }

    void Update()
    {
        fwd = gameObject.transform.TransformDirection(Vector3.forward);
        // Debug.DrawRay(gameObject.transform.position + 
        //new Vector3(0f, 1f, 0f), fwd * 50, Color.green);
        if (!trapped && !inRange) {
            resetGhoul();
            castForPlayer();
            if (!hasTarget) {
                handleNotChasing();
            } else {
                handleChasing();
            }
        } else {
            freezeGhoul();
        }
    }


  
    void resetGhoul()
    {
        hasSpoke = false;
        GetComponent<NavMeshAgent>().speed = 0.5f;
        animator.SetBool("IsWalking", true);
        agent.destination = targetDestinations[targetId].position;
    }

    void castForPlayer() {
        if (Physics.Raycast(gameObject.transform.position + new Vector3(0f, 1f, 0f), fwd, out objectHit, 20f))
        {
            if (objectHit.transform.tag == "Player")
            {
                GetComponent<NavMeshAgent>().speed = 3f;
                Debug.Log("Close to enemy" + objectHit.distance);
                if (!hasSpoke)
                {
                    GetComponent<AudioSource>().Play();
                    hasSpoke = true;
                }
                hasTarget = true;
            }
        }
    }
    void handleNotChasing() {
        if (animator.GetBool("IsRunning") == false)
        {
            animator.SetBool("IsWalking", true);
        }
        if (agent.remainingDistance < 0.5f)
        {
            targetId++;
        }
        if (targetId == targetDestinations.Length){
           targetId = 0;
        }    
        agent.destination = targetDestinations[targetId].position;
    }


    void handleChasing() {
        GetComponent<NavMeshAgent>().speed = 3f;
        agent.destination = player.position;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRunning", true);
    }

    void freezeGhoul() {
        GetComponent<NavMeshAgent>().speed = 0f;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRunning", false);
        StartCoroutine(waiter());
    }

    void OnTriggerEnter(Collider other) {
      
        if (other.gameObject.tag == "Player") {
            GetComponent<Animator>().SetBool("IsRunning", false);
            GetComponent<Animator>().SetBool("IsWalking", false);
            inRange = true;
            StartCoroutine(attackIfInRange());
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            inRange = false;
            StopCoroutine(attackIfInRange());
            resetGhoul(); 
        }
    }

 
    IEnumerator attackIfInRange() {
        
        while (inRange){
           
            Debug.Log("In range");
            GetComponent<Animator>().SetTrigger("Attack");
            Prefs.playerHealth -= 9;
            yield return new WaitForSeconds(2f);
        }
        
    }

    IEnumerator waiter()
    {
       
        while (trapped)
        {
            hasTarget = false;
            trapped = false;
            yield return new WaitForSeconds(5f);
        }
    }
}
