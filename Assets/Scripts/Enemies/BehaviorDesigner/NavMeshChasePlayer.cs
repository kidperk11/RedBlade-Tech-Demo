using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class NavMeshChasePlayer : Action
{
    public DetectionSphere detectionSphere;
    public SharedVector3 playerPosition;
    public SharedGameObject playerInstance;
    public NavMeshAgent navMeshAgent;
    public override void OnStart()
    {
        
    }
    public override TaskStatus OnUpdate()
    {
        Debug.Log("Player Position OnUpdate NavMeshChasePlayer: " + playerPosition.Value);
        playerPosition.SetValue(playerInstance.Value.transform.position);
        //this.transform.LookAt(new Vector3(playerPosition.Value.x, 0, playerPosition.Value.z), Vector3.up);
        navMeshAgent.SetDestination(playerPosition.Value);
        //if(Vector3.Distance(playerInstance.Value.transform.position,navMeshAgent.gameObject.transform.position) <= navMeshAgent.stoppingDistance)
        //{
        //    Debug.Log("Within attack range, navmesh.remainingDistance: " + Vector3.Distance(playerPosition.Value, navMeshAgent.gameObject.transform.position));
        //    navMeshAgent.isStopped = true;
        //}
        //Debug.Log("Player Position: " + playerPosition.Value);
        //Debug.Log("Enemy Position: " + skeletonBody.Value.transform.position);
        //Debug.Log("Distance between the two: " + Vector3.Distance(playerPosition.Value, skeletonBody.Value.transform.position));
        return TaskStatus.Running;
    }
}
