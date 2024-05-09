using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class OpponentAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Transform playerLocation;
    public LayerMask groundLayer, playerLayer;

    // Roaming state params
    private Vector3 destination;
    bool destinationSet;
    public float destinationRange;

    // Attack state params
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // Trigger params
    public bool isTakingAHit;
    public bool isDead;

    // General state params
    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;

    // On the first frame
    private void Start()
    {
        // Find the player
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent that is attached to this opponent
        agent = GetComponent<NavMeshAgent>();

        // Get the Animator that is attached to this opponent
        animator = GetComponent<Animator>();

        // Set isTakingAHit to false to indicate that the opponent is not currently taking a hit
        isTakingAHit = false;

        // Set isDead to false to indicate that the opponent is not dead
        isDead = false;
    }

    // Every frame
    private void Update()
    {
        // Check if the player is in sight range or attack range using a sphere with the radius set to the range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        // An improvised state switcher that, according to the player's position, will change the state of the opponent
        if (!isTakingAHit && !isDead)
        {
            if (!playerInSightRange && !playerInAttackRange)
            {
                Roaming();
            }
            else if (playerInSightRange && !playerInAttackRange)
            {
                Chasing();
            }
            else if (playerInAttackRange && playerInSightRange)
            {
                Attacking();
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeAHit(30f); // Assuming the opponent takes 30 damage when hit
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }



    private void Roaming()
    {
        // Toggle the chasing and attacking animations off
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", false);

        // Set the speed and acceleration of the opponent to default
        agent.speed = 2;
        agent.acceleration = 8;

        // If no destination is set, we find a new one
        if (!destinationSet) SearchDestination();

        // If a destination is set, we move towards it
        if (destinationSet)
            agent.SetDestination(destination);

        // Check if the opponent has reached the destination
        Vector3 distanceToDestination = transform.position - destination;

        // If the destination was reached
        if (distanceToDestination.magnitude < 1f)
        {
            // The destination is set to false so that a new one can be found in the next frame
            destinationSet = false;
        }
    }

    private void Chasing()
    {
        Debug.Log("Chasing");
        // Increase the speed and acceleration of the opponent
        agent.speed = 3;
        agent.acceleration = 8;

        // Toggle the chasing animation
        animator.SetBool("isAttacking", false);
        animator.SetBool("isChasing", true);

        // Move towards the player
        agent.SetDestination(playerLocation.position);
    }

    private void Attacking()
    {
        Debug.Log("Attacking");

        // Stop the opponent from moving
        agent.speed = 0;
        agent.acceleration = 0;

        // If the opponent has not already attacked
        if (!alreadyAttacked)
        {
            // Make the opponent look at the player
            transform.LookAt(playerLocation);

            // Toggle the chasing animation off and the attacking animation on
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", true);

            // Get the opponent's attack power
            float atk = GetComponent<Stats>().atk;

            // If the player exists, deal damage to the player
            if (playerLocation != null)
            {
                // Find the player GameObject
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                // Deal damage to the player
                player.GetComponent<Stats>().TakeDamage(atk);
            }

            // Prevent the opponent from attacking again until the time between attacks has passed
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        Debug.Log("Resetting attack");
        // Reset the attacking animation
        animator.SetBool("isAttacking", false);
        alreadyAttacked = false;
    }

    public void TakeAHit(float damage)
    {
        // Stop the opponent from moving
        agent.speed = 0;
        agent.acceleration = 0;
        agent.SetDestination(transform.position);

        // Set the hit trigger
        animator.SetTrigger("hit");

        // Set the isTakingAHit to true to indicate that the opponent is currently taking a hit
        isTakingAHit = true;

        // Deduct the damage from the hp
        GetComponent<Stats>().TakeDamage(damage);

        // Reset the hit trigger
        Invoke(nameof(ResetHit), 1.183f);
    }

    private void ResetHit()
    {
        // Reset the hit trigger
        animator.ResetTrigger("hit");
        
        // Set the isTakingAHit to false to indicate that the opponent is no longer taking a hit
        isTakingAHit = false;
    }

    public void Die()
    {
        Debug.Log(gameObject.name + " died");

        // Stop the opponent from moving
        agent.speed = 0;
        agent.acceleration = 0;
        agent.SetDestination(transform.position);

        // Set the die trigger
        animator.SetTrigger("die");

        // Set the isDead to true to indicate that the opponent is dead
        isDead = true;

        // Destroy the opponent after the death animation has played
        Destroy(gameObject, 4.583f);
    }

    private void SearchDestination()
    {
        Debug.Log("Searching destination");
        // Calculate a random position within the destination range
        float randomZ = Random.Range(-destinationRange, destinationRange);
        float randomX = Random.Range(-destinationRange, destinationRange);

        // Set the destination to the random position that was calculated
        destination = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Check if the destination is not out of bounds
        if (Physics.Raycast(destination, -transform.up, 2f, groundLayer))
        {
            // If the destination is valid, set the destinationSet to true
            destinationSet = true;
        }
    }
}
