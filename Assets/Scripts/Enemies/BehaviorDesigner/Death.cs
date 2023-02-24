using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class Death : Conditional
{
    public EnemyHealth health;
    public MeshExploder exploder;
    public Animator anim;
    public SkinnedMeshRenderer mesh;
    public List<GameObject> objectsThatNeedToBeTurnedOff;
    public override TaskStatus OnUpdate()
    {
        if (health.isDead)
        {
            foreach (GameObject childObjects in objectsThatNeedToBeTurnedOff)
            {
                if (childObjects != null)
                {
                    childObjects.SetActive(false);
                }
            }
            anim.SetTrigger("death");
            return TaskStatus.Failure;
        }
        return TaskStatus.Success;
    }
}
