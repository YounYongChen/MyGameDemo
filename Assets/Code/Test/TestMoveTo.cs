using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMoveTo : MonoBehaviour
{

    [SerializeField]
    private Transform _target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>() as NavMeshAgent;
      
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = _target.position;
    }
}
