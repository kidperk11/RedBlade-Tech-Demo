using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class KatanaParry : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private AttackHitbox attackHitbox;
    public float playerPostureDamage;
    public static bool parryInput;

    private void Start()
    {
        //playerInput = GetComponent<PlayerInput>();

    }

    private void Update()
    {
        if (parryInput)
        {
            OnParry();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ParriableHitbox"))
        {
            attackHitbox = other.gameObject.GetComponent<AttackHitbox>();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ParriableHitbox"))
        {
            attackHitbox = null;
        }
    }

    public void OnParry()
    {
        if(attackHitbox != null)
        {
            Debug.Log("Parry input triggered, checking for parry window");
            attackHitbox.CheckParry(playerPostureDamage);
        }
        else
        {
            Debug.Log("The Parry input has been triggered");
        }
        parryInput = false;
    }
}
