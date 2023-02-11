using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotationScript : MonoBehaviour
{
    public Transform headCamera;
    public Transform bodyObject;
    public float rotationBuffer;
    private float distanceToHighEnd;
    private float distanceToLowEnd;
    private float camBodyDistance;

    // Update is called once per frame
    void FixedUpdate()
    {
        float cameraRotation = 0;
        float bodyRotation = 0;
        
        cameraRotation = headCamera.transform.eulerAngles.y;
        Debug.Log("Raw Camera Rotation: " + cameraRotation);
        bodyRotation = bodyObject.transform.eulerAngles.y;
        Debug.Log("Raw Body Rotation: " + bodyRotation);


        //Checks if the rotation is negative
        if(cameraRotation < 0){
            //adds 360 to the cameraRotation until it's value is greater than 0;
            while(cameraRotation < 0){
                cameraRotation += 360;
            }
            Debug.Log("Initial Camera Rotation: " + cameraRotation);

        //Checks if the rotation is over 360
        }else if(cameraRotation > 360){
            //subtracts 360 from the cameraRotation until it's value is less than 360;
            while(cameraRotation > 360){
                cameraRotation -= 360;
            }
            Debug.Log("Initial Camera Rotation: " + cameraRotation);
        }

        //Checks if the rotation is negative
        if(bodyRotation < 0){
            //adds 360 to the bodyRotation until it's value is greater than 0;
            while(bodyRotation < 0){
                bodyRotation += 360;
            }
            Debug.Log("Initial Body Rotation: " + bodyRotation);

        //Checks if the rotation is over 360
        }else if(bodyRotation > 360){
            //subtracts 360 from the bodyRotation until it's value is less than 360;
            while(bodyRotation > 360){
                bodyRotation -= 360;
            }
            Debug.Log("Initial Body Rotation: " + bodyRotation);
        }
        if(cameraRotation > bodyRotation){
            camBodyDistance = cameraRotation - bodyRotation;
        }else if(cameraRotation<bodyRotation){
            camBodyDistance = bodyRotation - cameraRotation;
        }
        float highEnd = cameraRotation + rotationBuffer;
        float lowEnd = cameraRotation - rotationBuffer;
        if(highEnd>360){
            highEnd-=360;
        }
        if(lowEnd<0){
            lowEnd+=360;
        }
        distanceToHighEnd = Mathf.Abs(Mathf.DeltaAngle(highEnd, bodyRotation));
        distanceToLowEnd = Mathf.Abs(Mathf.DeltaAngle(lowEnd, bodyRotation));

        if(Mathf.Abs(Mathf.DeltaAngle(bodyRotation, cameraRotation)) > rotationBuffer){
            Debug.Log("Distance to points (Calling rotation): " + Mathf.DeltaAngle(bodyRotation, cameraRotation));
            Debug.Log("Camera Rotation: " + cameraRotation + " and Body Rotation: " + bodyRotation);
            if(distanceToHighEnd > distanceToLowEnd){
                bodyObject.eulerAngles = new Vector3(this.transform.eulerAngles.x, lowEnd, this.transform.eulerAngles.z);
            }else if(distanceToHighEnd < distanceToLowEnd){
                bodyObject.eulerAngles = new Vector3(this.transform.eulerAngles.x, highEnd, this.transform.eulerAngles.z);
            }
        }
        bodyObject.position = new Vector3(headCamera.position.x, this.transform.position.y, headCamera.position.z);
    }
}
