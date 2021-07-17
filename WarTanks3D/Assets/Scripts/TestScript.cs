using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(123);
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
