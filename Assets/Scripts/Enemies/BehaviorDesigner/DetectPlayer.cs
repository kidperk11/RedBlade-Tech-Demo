using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class DetectPlayer : Conditional
{
    public DetectionSphere detectionSphere;
    public SharedVector3 m_playerPosition;
    public SharedGameObject m_playerInstance;
    public Animator anim;

    public override TaskStatus OnUpdate(){
        if(detectionSphere.targetDetected){
            Debug.Log(detectionSphere.target.transform.position);
            //GlobalVariables.Instance.GetVariable("Player").SetValue(detectionSphere.target.transform.position);
            m_playerPosition.SetValue(new Vector3(detectionSphere.target.transform.position.x, this.transform.position.y, detectionSphere.target.transform.position.z));
            m_playerInstance.SetValue(detectionSphere.target);
            //anim.SetTrigger("walk");
            Debug.Log("Player Position: " + m_playerPosition);
            Debug.Log("Player Instance: " + m_playerInstance);
            return TaskStatus.Success;
        }else{return TaskStatus.Failure;}
    }
}
