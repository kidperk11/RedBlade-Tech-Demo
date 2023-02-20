using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CriticalDeath : Conditional
{
    public EnemyHealth health;
    public MeshExploder exploder;
    public Animator anim;
    public SkinnedMeshRenderer mesh;
    public List<GameObject> objectsThatNeedToBeTurnedOff;
    public override TaskStatus OnUpdate()
    {
        if (health.isCriticalDead)
        {
            foreach(GameObject childObjects in objectsThatNeedToBeTurnedOff)
            {
                if (childObjects != null)
                {
                    childObjects.SetActive(false);
                }
                
            }
            mesh.enabled = false;
            anim.StopPlayback();
            exploder.Explode();
            return TaskStatus.Failure;
        }
        return TaskStatus.Success;
    }
}
