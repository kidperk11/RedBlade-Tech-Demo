using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CriticalParryState : Conditional
{
    public EnemyHealth health;
    public List<GameObject> criticalHitPoints;
    public int randomCritPointIndex;
    public GameObject activeCritPoint;
    public Animator anim;
    public float animSlowSpeed;

    public override void OnStart()
    {
        randomCritPointIndex = -1;
        activeCritPoint = null;
    }

    // Update is called once per frame
    public override TaskStatus OnUpdate()
    {
        if (health.criticalParryOpening)
        {
            if(randomCritPointIndex == -1)
            {
                anim.SetBool("postureBreak", true);
                //anim.speed = animSlowSpeed;
                randomCritPointIndex = Random.Range(0, criticalHitPoints.Count - 1);
                criticalHitPoints[randomCritPointIndex].SetActive(true);
                activeCritPoint = criticalHitPoints[randomCritPointIndex];
            }
            if (!activeCritPoint.activeInHierarchy)
            {
                //anim.speed = 1;
                anim.SetBool("postureBreak", false);
                randomCritPointIndex = -1;
                activeCritPoint = null;
                health.criticalParryOpening = false;
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
        return TaskStatus.Success;
    }

    
}
