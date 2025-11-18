using UnityEngine;
using UnityEngine.AI;

public class Aiagent : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] waypoints;
    int wayPointIndex;
    Vector3 target;

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
    }

    void updateDestination() 
    {
        target = waypoints[wayPointIndex].position;
        agent.SetDestination(target);
    }

    void IterateIndex() 
    { 
        wayPointIndex++;
        if (wayPointIndex >= waypoints.Length) 
        {
            wayPointIndex = 0;
        } 
    }
}
