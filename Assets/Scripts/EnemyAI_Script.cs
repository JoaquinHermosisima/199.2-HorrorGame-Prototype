using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing;
    public Transform player;
    public Transform respawnPoint; // Assign this in the Inspector
    Transform currentDest;
    Vector3 dest;
    int randNum;
    public Vector3 rayCastOffset;

    public AudioSource runningSound;

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
        runningSound = GetComponent<AudioSource>();
        runningSound.enabled = false;
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
        }
        if (chasing)
        {
            runningSound.enabled = true;
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            float distance = Vector3.Distance(player.position, ai.transform.position);
            if (distance <= catchDistance)
            {
                RespawnPlayer(); // Respawn player instead of disabling them
                chasing = false;
            }
        }
        if (walking)
        {
            runningSound.enabled = false;
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }

void RespawnPlayer()
{
    Rigidbody rb = player.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.velocity = Vector3.zero; // Stop any movement
        rb.angularVelocity = Vector3.zero; // Reset rotation movement
    }

    player.position = respawnPoint.position; // Move player to respawn point
    Debug.Log("Player has respawned!");
}

    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) // Ensure your player has the tag "Player"
    {
        RespawnPlayer();
    }
}

}