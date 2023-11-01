using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent enemyAI;
    private bool playerDetected;
    private Animator enemyAnim;
    private Vector3 randomLocation;
    private float waitingTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<NavMeshAgent>();
        playerDetected = false;
        enemyAnim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (playerDetected == true && distance > 4)
        {
            enemyAI.destination = playerTransform.position;
            enemyAnim.SetBool("running", true);
        }
        else
        {
            if (!enemyAI.hasPath && waitingTime < Time.time && playerDetected == false)
            {
                randomLocation = new Vector3(Random.Range(-28.43f, 13.61f), transform.position.y, Random.Range(-41.6f, -3.39f));
                enemyAI.destination = randomLocation;
                enemyAnim.SetBool("running", true);
                Debug.Log(randomLocation);
            }
            else
            {
                if(playerDetected == true && distance <= 4)
                {
                    //enemyAI.velocity = Vector3.zero;
                    enemyAnim.SetTrigger("attack");
                    //transform.LookAt(playerTransform.position);
                    //Debug.Log(distance);
                }
            }
        }
        //enemyAI.destination = playerTransform.position;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerDetected = true;
            Debug.Log("jugador detectado");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
