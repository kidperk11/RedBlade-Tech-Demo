using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Block : Action
{
    public float blockTimer;
    public SharedBool isAttacking;
    public Animator anim;
    // Start is called before the first frame update
    public override void OnStart()
    {
        anim.SetBool("block", true);
        blockTimer = Random.Range(2, 4);
    }

    // Update is called once per frame
    public override TaskStatus OnUpdate()
    {
        blockTimer -= Time.deltaTime;
        if (blockTimer <= 0)
        {
            anim.SetTrigger("attack");
            isAttacking.Value = true;
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
