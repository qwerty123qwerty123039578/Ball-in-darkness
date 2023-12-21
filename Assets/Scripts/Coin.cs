using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coin : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public float range = 10f;
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.isStopped = false;
        navAgent.speed = 3;
    }
    private void Update()
    {
        //GoRandom();
    }
    void GoRandom()
    {
        Vector3 point;
        if (!navAgent.hasPath && RandomPoint(transform.position, range, out point))
        {
            navAgent.SetDestination(point);
            Debug.DrawRay(point, Vector3.up, Color.blue, 35);
        }
    }
    bool RandomPoint(Vector3 center,float range,out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 0.1f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
