using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class Attack : Action
{
    public float maxAttackTime;
    public float attackTimer;
    public SharedBool isAttacking;
    public Animator anim;
    // Start is called before the first frame update
    public override void OnStart()
    {
        attackTimer = maxAttackTime;
        isAttacking.Value = true;
    }

    // Update is called once per frame
    public override TaskStatus OnUpdate()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            //anim.SetTrigger("block");
            isAttacking.Value = false;
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
