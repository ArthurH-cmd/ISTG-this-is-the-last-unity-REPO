using System;
using UnityEngine;
using UnityEngine.AI;

public class Aiagent : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] waypoints;
    int wayPointIndex;
    Vector3 target;
    [SerializeField] GameObject player = null;

    [SerializeField] float ChaseSpeed = 10.0f;
    float defultSpeed = 5;

    [SerializeField] float MaxRaycastRange = 20.0f; // how far the ai can "see"
    [SerializeField] float HowFarWillTheAiHuntYou = 1.0f; // how far the ai will chase you

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        updateDestination();

  
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, target) < 1) 
        {
            IterateIndex();
            updateDestination();
        }

        Raycasting();
    }

    void updateDestination() 
    {
        if (waypoints.Length == 0) return; 
        target = waypoints[wayPointIndex].position;
        agent.SetDestination(target);
        Debug.Log($"AI moving to waypoint {wayPointIndex}: {target}");
    }

    void IterateIndex() 
    { 
        wayPointIndex++;
        if (wayPointIndex >= waypoints.Length) 
        {
            wayPointIndex = 0;
        } 
    }

    private void Raycasting()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, MaxRaycastRange); 
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Rob")) 
            {
                Vector3 directionToTarget = (hit.transform.position - transform.position).normalized;
                float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

                if (angleToTarget < 45f) // Check if the target is within a 90-degree cone (45 degrees on each side)
                {
                    Debug.Log($"ConeCast hit: {hit.name}");
                    RaycastHit(hit.transform);
                    return;
                }
            }
        }

     
        BackToWaypoints(); 
    }

    private void RaycastHit(Transform targetPos)
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, targetPos.position);

       
        agent.speed = ChaseSpeed;
        agent.SetDestination(player.transform.position); 

        if (distanceFromPlayer > HowFarWillTheAiHuntYou)
        {
           
            BackToWaypoints(); 
        }
    }

    private void BackToWaypoints()
    {
        agent.speed = defultSpeed;
    
        agent.isStopped = false;
        updateDestination();
    }

    private void OnDrawGizmos() // drawing the cone
    {
   
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MaxRaycastRange);

    
        Gizmos.color = Color.red;
        Vector3 forward = transform.forward * MaxRaycastRange;
        Vector3 leftBoundary = Quaternion.Euler(0, -45f, 0) * forward; // 45 degrees to the left
        Vector3 rightBoundary = Quaternion.Euler(0, 45f, 0) * forward; // 45 degrees to the right

        Gizmos.DrawRay(transform.position, forward); 
        Gizmos.DrawRay(transform.position, leftBoundary); // Left boundary of the cone
        Gizmos.DrawRay(transform.position, rightBoundary); // Right boundary of the cone
    }
}
