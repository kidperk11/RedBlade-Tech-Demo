using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WithinAttackRange : Conditional
{
    public float attackRange;
    public DetectionSphere detectionSphere;
    public Vector3 defaultDetectionScale;
    public Vector3 attackingDetectionScale;
    public SharedVector3 playerPosition;
    public SharedGameObject playerInstance;
    public SharedGameObject skeletonBody;
    public Animator anim;
    public SharedBool isAttacking;

    public override void OnStart()
    {
        base.OnStart();
        anim.SetBool("block", false);
    }
    public override TaskStatus OnUpdate()
    {      
        if (detectionSphere.targetDetected)   
        {
            if (!isAttacking.Value)
            {
                anim.ResetTrigger("walk");
                //anim.SetTrigger("block");
                detectionSphere.gameObject.transform.localScale = attackingDetectionScale;
                return TaskStatus.Success;
            }

        }
        else
        {
            anim.SetTrigger("walk");
            detectionSphere.gameObject.transform.localScale = defaultDetectionScale; 
        }

        return TaskStatus.Failure;
        //if ((detectionSphere.targetDetected || Vector3.Distance(playerInstance.Value.transform.position, skeletonBody.Value.transform.position) < attackRange) && !isAttacking.Value)
    }
}
