using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgent : MonoBehaviour
{
    private NavMeshAgent _agent;
    public float baseSpeed;
    private Transform _moveTarget;
    private void Start()
    {
        _agent = GetComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        baseSpeed = this.GetComponent<NavMeshAgent>().speed;
    }
    private void Update()
    {
        _agent.SetDestination(_moveTarget.position);
        // print(_moveTarget.position);
        var diffx = _moveTarget.position.x - transform.position.x;
        var diffz = _moveTarget.position.z - transform.position.z;
        if (diffx < 4 && diffx > -4 && diffz < 4 && diffz > -4){
            Destroy(gameObject);
        }
    }

    public void setTarget(Transform target)
    {
        _moveTarget = target;
    }
}
