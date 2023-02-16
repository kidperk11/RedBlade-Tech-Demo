using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class ChasePlayer : Action
{
    public DetectionSphere detectionSphere;
    public SharedVector3 playerPosition;
    public SharedGameObject playerInstance;
    public SharedGameObject skeletonBody;
    public float attackRange;
    public float moveSpeed;
    public override void OnStart()
    {
        
    }
    public override TaskStatus OnUpdate()
    {
        playerPosition.SetValue(playerInstance.Value.transform.position);
        this.transform.LookAt(new Vector3(playerPosition.Value.x, 0, playerPosition.Value.z), Vector3.up);
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(playerPosition.Value.x, 0, playerPosition.Value.z), moveSpeed * Time.deltaTime);
        Debug.Log("Player Position: " + playerPosition.Value);
        Debug.Log("Enemy Position: " + skeletonBody.Value.transform.position);
        Debug.Log("Distance between the two: " + Vector3.Distance(playerPosition.Value, skeletonBody.Value.transform.position));
        if(Vector3.Distance(playerPosition.Value, skeletonBody.Value.transform.position) < attackRange){

            return TaskStatus.Success;
            Debug.Log("Task Has Failed");
        }
        return TaskStatus.Running;
    }
}
