using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSphere : MonoBehaviour
{
    public string targetTag;
    public bool targetDetected;
    public GameObject target;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag(targetTag)){
            target = other.gameObject;
            targetDetected = true;
        }
            //Debug.Log("Collision with tag: " + other.tag);
            //Debug.Log("Object Name: " + other.gameObject);
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag(targetTag)){
            // target = null;
            targetDetected = false;
        }
    }
}
