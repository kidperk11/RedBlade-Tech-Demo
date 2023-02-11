using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class KatanaXR : XRGrabInteractable
{
    public Vector3 katanaHolsterPoint;
    public Vector3 katanaHolsterRotation;
    private void Start() {
        
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        //This code sets the katana back into it's holster after one of
        //the hands releases it.

        this.transform.localPosition = katanaHolsterPoint;
        this.transform.localRotation = Quaternion.Euler(katanaHolsterRotation);
        Debug.Log("Katana has been released, position set to: " + transform.position);
        Debug.Log("Rotation set to: " + transform.rotation);
    }
}
