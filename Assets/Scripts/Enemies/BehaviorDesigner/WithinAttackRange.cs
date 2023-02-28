using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WithinAttackRange : Conditional
{
    public float attackRange;
    public SharedVector3 playerPosition;
    public SharedGameObject playerInstance;
    public SharedGameObject skeletonBody;
    public float attackDetectionDistance;
    public NavMeshAgent navMeshAgent;
    public Animator anim;
    public SharedBool isAttacking;
    public bool inAttackRange;

    public override void OnStart()
    {
        base.OnStart();
        anim.SetBool("block", false);
        inAttackRange = false;
    }
    public override TaskStatus OnUpdate()
    {
        Debug.Log("Navmesh Stopped: " + navMeshAgent.isStopped + " NavMesh Distance Remaining: " + Vector3.Distance(playerInstance.Value.transform.position, skeletonBody.Value.transform.position) + " NavMesh Stopping Distance: " + navMeshAgent.stoppingDistance);
        if (Vector3.Distance(playerInstance.Value.transform.position, skeletonBody.Value.transform.position) <= navMeshAgent.stoppingDistance)
        {
            
                anim.ResetTrigger("walk");
                inAttackRange = true;
                return TaskStatus.Success;
            
        }else if (Vector3.Distance(playerInstance.Value.transform.position, skeletonBody.Value.transform.position) < attackDetectionDistance && Vector3.Distance(playerInstance.Value.transform.position, skeletonBody.Value.transform.position) > navMeshAgent.stoppingDistance && inAttackRange)
        {
            
                inAttackRange = true;
                anim.ResetTrigger("walk");
                return TaskStatus.Success;
            
        }else if(Vector3.Distance(playerInstance.Value.transform.position, skeletonBody.Value.transform.position) >= attackDetectionDistance)
        {
            if (!isAttacking.Value)
            {
                Debug.Log("Player has left the attack range, resuming chase");
                anim.SetTrigger("walk");
                inAttackRange = false;
                return TaskStatus.Failure;
            }    
        }


        //if (!isAttacking.Value)
        //{
        //    anim.ResetTrigger("walk");
        //    return TaskStatus.Success;
        //}

        return TaskStatus.Failure;
    }
}
