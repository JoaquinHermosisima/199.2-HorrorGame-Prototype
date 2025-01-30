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
    private Transform currentDest;
    private Vector3 dest;
    private int randNum;
    public Vector3 rayCastOffset;

    public AudioSource runningSound;
    public AudioSource walkingSound;

    // Jumpscare variables
    public GameObject jumpscareUI; // Assign in Inspector
    public AudioSource jumpscareSound; // Assign in Inspector

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];

        if (jumpscareUI != null)
        {
            jumpscareUI.SetActive(false); // Hide jumpscare UI initially
        }
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
            // Play the first sound if it's not already playing
            if (!runningSound.isPlaying)
            {
                runningSound.Play();
                runningSound.loop = true; // Set to loop
            }

            // Stop the second sound if it's playing
            if (walkingSound.isPlaying)
            {
                walkingSound.Stop();
            }
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            float distance = Vector3.Distance(player.position, ai.transform.position);
            if (distance <= catchDistance)
            {
                StartCoroutine(JumpscareRoutine()); // Trigger jumpscare before respawning
                
                chasing = false;
            }
        }

        if (walking)
        {
            // Play the first sound if it's not already playing
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
                walkingSound.loop = true; // Set to loop
            }

            // Stop the second sound if it's playing
            if (runningSound.isPlaying)
            {
                runningSound.Stop();
            }
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

    IEnumerator JumpscareRoutine()
    {
        // Disable player movement
        DisablePlayerControls();

        // Play jumpscare sound FIRST before enabling UI
    if (jumpscareSound != null)
    {
        jumpscareSound.Stop();
        jumpscareSound.PlayOneShot(jumpscareSound.clip);
    }

        // Small delay before enabling UI (Optional, tweak this value)
        yield return new WaitForSeconds(0.8f); 

        // Show jumpscare UI
        if (jumpscareUI != null)
        {
            jumpscareUI.SetActive(true);
        }

        // Wait for jumpscare duration
        yield return new WaitForSeconds(jumpscareTime);

        // Hide jumpscare UI
        if (jumpscareUI != null)
        {
            jumpscareUI.SetActive(false);
        }

        // Enable player movement
        EnablePlayerControls();

        // Respawn the player
        RespawnPlayer();
    }

    void RespawnPlayer()
    {
        if (respawnPoint == null)
        {
            Debug.LogError("Respawn Point is not assigned!");
            return;
        }

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.MovePosition(respawnPoint.position);
        }
        else
        {
            player.position = respawnPoint.position;
        }

        Debug.Log($"Player has respawned at: {respawnPoint.position}");
        Physics.SyncTransforms();
    }

    void DisablePlayerControls()
    {
        var playerController = player.GetComponent<MonoBehaviour>(); // Generic approach
        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }

    void EnablePlayerControls()
    {
        var playerController = player.GetComponent<MonoBehaviour>(); // Generic approach
        if (playerController != null)
        {
            playerController.enabled = true;
        }
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
        if (other.CompareTag("Player"))
        {
            StartCoroutine(JumpscareRoutine());
        }
    }
}
