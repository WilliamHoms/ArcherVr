using UnityEngine;
using System.Linq;
using System.Collections;


public class AI_StateMachine : MonoBehaviour
{

    public Transform[] target;
    public GameObject[] allChildren;
    private GameObject pathObject;
    private int destPoint = 0;
    NavMeshAgent agent;
    private float distance = 0.0f;


    void Start()
    {
        target = new Transform[10];
        agent = GetComponent<NavMeshAgent>();
        allChildren = GameObject.FindGameObjectsWithTag("FirstPath").OrderBy(go => go.name).ToArray();

        // Disabling auto-braking allows for continuous movement between points
        agent.autoBraking = false;
    }

    void Update()
    {
        target[destPoint] = allChildren[destPoint].GetComponent<Transform>();
        if (agent.remainingDistance < 0.5f)
            GotoNextPath();


    }

    void GotoNextPath()
    {
        // Returns if no points have been set up
        if (target.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = target[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % target.Length;
    }
}