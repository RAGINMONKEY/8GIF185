using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgent : MonoBehaviour
{
    private NavMeshAgent _agent;
    public float baseSpeed;
    public GameObject _moveTarget;
    private void Start()
    {
        _agent = GetComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        baseSpeed = this.GetComponent<NavMeshAgent>().speed;
    }
    private void Update()
    {
        _agent.SetDestination(_moveTarget.transform.position);

        var diffx = _moveTarget.transform.position.x - transform.position.x;
        var diffz = _moveTarget.transform.position.z - transform.position.z;
        if (diffx < 2 && diffx > -2 && diffz < 2 && diffz > -2){
            Destroy(gameObject);
        }
    }
}
