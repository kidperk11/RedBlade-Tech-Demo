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
    private bool outOfBuffer;
    private void Start() {

    }

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
        //After performing those two sets of if loops, we now have the real rotation
        //from 0 to 360 for the camera and the body.

        //The Update function then checks to see if the body and camera are within
        //the rotation buffer. If they are outside the buffer, the if statements set
        //them within the buffer and sets the body's y rotation.
        if(cameraRotation > bodyRotation){
            camBodyDistance = cameraRotation - bodyRotation;
        }else if(cameraRotation<bodyRotation){
            camBodyDistance = bodyRotation - cameraRotation;
        }
        float highEnd = cameraRotation + rotationBuffer;
        float lowEnd = cameraRotation - rotationBuffer;
        if(highEnd>360){
            highEnd-=360;
            //73.4311
        }
        if(lowEnd<0){
            lowEnd+=360;
            //253.4311
        }
        distanceToHighEnd = Mathf.Abs(Mathf.DeltaAngle(highEnd, bodyRotation));
        Debug.Log("distanceToHighEnd =" +  Mathf.DeltaAngle(highEnd, bodyRotation));
        Debug.Log("distanceToLowEnd =" +  Mathf.DeltaAngle(lowEnd, bodyRotation));
        distanceToLowEnd = Mathf.Abs(Mathf.DeltaAngle(lowEnd, bodyRotation));

        // if(highEnd>bodyRotation){
        //     distanceToHighEnd = highEnd - bodyRotation;
        // }else if(highEnd<bodyRotation){
        //     distanceToHighEnd = bodyRotation - highEnd;
        // }

        // if(lowEnd>bodyRotation){
        //     distanceToLowEnd = lowEnd - bodyRotation;
        // }else if(lowEnd<bodyRotation){
        //     distanceToLowEnd = bodyRotation - lowEnd;
        // }
            Debug.Log("Distance to points: " + Mathf.DeltaAngle(bodyRotation, cameraRotation));

        
        if(Mathf.Abs(Mathf.DeltaAngle(bodyRotation, cameraRotation)) > rotationBuffer){
            Debug.Log("Distance to points (Calling rotation): " + Mathf.DeltaAngle(bodyRotation, cameraRotation));
            Debug.Log("Camera Rotation: " + cameraRotation + " and Body Rotation: " + bodyRotation);
            // float highEnd = cameraRotation + rotationBuffer;
            // float lowEnd = cameraRotation - rotationBuffer;
            // if(highEnd>360){
            //     highEnd-=360;
            // }
            // if(lowEnd<0){
            //     lowEnd+=360;
            // }

            
            

            if(distanceToHighEnd > distanceToLowEnd){
                bodyObject.eulerAngles = new Vector3(this.transform.eulerAngles.x, lowEnd, this.transform.eulerAngles.z);
            }else if(distanceToHighEnd < distanceToLowEnd){
                bodyObject.eulerAngles = new Vector3(this.transform.eulerAngles.x, highEnd, this.transform.eulerAngles.z);
            }


            //NOTE: This code works but still has the jitter issue
            // if(cameraRotation > bodyRotation){
            //     // while((cameraRotation - rotationBuffer) > bodyRotation){
            //     //     bodyRotation += rotationBuffer;
            //     // }
                
            //     bodyObject.eulerAngles = new Vector3(this.transform.eulerAngles.x, (cameraRotation), this.transform.eulerAngles.z);

            //     Debug.Log("Final Body Rotation: " + this.transform.eulerAngles);
            // }
            // else if(cameraRotation < bodyRotation){
            //     // while((cameraRotation + rotationBuffer) < bodyRotation){
            //     //     bodyRotation -= rotationBuffer;
            //     // }
            //     bodyObject.eulerAngles = new Vector3(this.transform.eulerAngles.x, (cameraRotation), this.transform.eulerAngles.z);

            //     Debug.Log("Final Body Rotation: " + this.transform.eulerAngles);
            // }

            //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, bodyRotation, this.transform.rotation.z);
        }

        bodyObject.position = new Vector3(headCamera.position.x, this.transform.position.y, headCamera.position.z);
        outOfBuffer = false;
    }
}
