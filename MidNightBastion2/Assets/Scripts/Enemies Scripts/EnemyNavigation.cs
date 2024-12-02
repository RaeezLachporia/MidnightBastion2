using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private Transform movePostionTransform;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        movePostionTransform = GameObject.Find("Tower").transform;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    private void Update()
    {
        agent.destination = movePostionTransform.position;
    }
}
