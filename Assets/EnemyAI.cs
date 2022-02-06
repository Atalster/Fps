using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform _player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling'
    public Vector3 walkPoint;
    private bool walkPointSet;
    private float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;


    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        //stages
        if (!playerInSightRange) Patrolling();
        if (playerInSightRange) ChasePlayer(); 
     
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint Reached
        if (distanceToWalkPoint.magnitude < 1f)
        walkPointSet = false;
    }
 private void SearchWalkPoint()

{
    //Calculate random point in range
    float randomZ = Random.Range(-walkPointRange, walkPointRange);
  float randomX = Random.Range(-walkPointRange, walkPointRange);  

  walkPoint = new Vector3 (transform.position.x + randomX, transform.position.z + randomZ);
  if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
  walkPointSet = true;
}   


  private void ChasePlayer()
    {
        agent.SetDestination(_player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
