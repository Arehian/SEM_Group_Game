using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent agent;
    public Transform destination;

    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      agent.destination = destination.position;
    }

    // Update is called once per frame
    void Update()
    {

      agent = GetComponent<NavMeshAgent>();
      agent.destination = destination.position;

    }
}
