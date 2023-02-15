using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class DetectPlayer : Conditional
{
    public DetectionSphere detectionSphere;
    public SharedVector3 playerPosition;
    public SharedGameObject playerInstance;

    public override TaskStatus OnUpdate(){
        if(detectionSphere.targetDetected){
            Debug.Log(detectionSphere.target.transform.position);
            //GlobalVariables.Instance.GetVariable("Player").SetValue(detectionSphere.target.transform.position);
            playerPosition.Value = new Vector3(detectionSphere.target.transform.position.x, 0, detectionSphere.target.transform.position.z);
            playerInstance.Value = detectionSphere.target;
            return TaskStatus.Failure;
        }else{return TaskStatus.Running;}
    }
}
