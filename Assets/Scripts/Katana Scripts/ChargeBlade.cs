using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBlade : MonoBehaviour
{
    public bool leftHandOnHandle;
    public bool rightHandOnHandle;
    [SerializeField] private float maxChargeTime;
    public float timerForCharge;
    public Color defaultColor;
    public Color chargedColor;
    public Vector3 colorGradient;
    public Material bladeMaterial;
    public bool attackReady;

    private void Start()
    {
        timerForCharge = 0;
        bladeMaterial.color = defaultColor;
    }

    private void Update()
    {
        if(leftHandOnHandle && rightHandOnHandle && timerForCharge <= maxChargeTime)
        {
            timerForCharge += Time.deltaTime;
            colorGradient = Vector3.Lerp(new Vector3(defaultColor.r, defaultColor.g, defaultColor.b), new Vector3(chargedColor.r, chargedColor.g, chargedColor.b), timerForCharge / maxChargeTime);
            bladeMaterial.color = new Color(colorGradient.x, colorGradient.y, colorGradient.z, 255);
            attackReady = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left Hand")){
            leftHandOnHandle = true;
        }
        if (other.CompareTag("Right Hand"))
        {
            rightHandOnHandle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Left Hand"))
        {
            leftHandOnHandle = false;
        }
        if (other.CompareTag("Right Hand"))
        {
            rightHandOnHandle = false;
        }
    }
}
