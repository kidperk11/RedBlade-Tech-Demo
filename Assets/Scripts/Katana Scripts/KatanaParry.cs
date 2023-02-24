using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KatanaParry : MonoBehaviour
{
    public AttackHitbox attackHitbox;
    public float playerPostureDamage;

    public PlayerHealth playerHealth;

    [SerializeField] private AudioSource negativeClashSound;
    [SerializeField] private AudioSource neutralClashSound;
    [SerializeField] private AudioSource positiveClashSound;
    [SerializeField] private AudioSource criticalClashSound;


    private void Start()
    {

    }

    private void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ParriableHitbox"))
        {
            attackHitbox = other.gameObject.GetComponent<AttackHitbox>();
            attackHitbox.katanaInstance = this;
        }
    }
    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("ParriableHitbox"))
    //    {
    //        attackHitbox = null;
    //    }
    //}

    public void OnParry()
    {
        //negativeClashSound.Play();
        if(attackHitbox != null)
        {
            Debug.Log("Parry input triggered, checking for parry window");
            attackHitbox.CheckParry(playerPostureDamage);
            if(attackHitbox.negativeWindow)
            {
                negativeClashSound.Play();
            }else if(attackHitbox.neutralWindow)
            {
                neutralClashSound.Play();
            }else if (attackHitbox.positiveWindow)
            {
                positiveClashSound.Play();
            }else if (attackHitbox.criticalWindow)
            {
                criticalClashSound.Play();
            }
        }
        else
        {
            Debug.Log("The Parry input has been triggered");
        }
    }

    public void PlayParrySound(string parryLevel)
    {
        if(parryLevel == "negative")
        {
            negativeClashSound.Play();
        }
        if(parryLevel == "neutral")
        {
            neutralClashSound.Play();
        }
        if(parryLevel == "positive")
        {
            positiveClashSound.Play();
        }
        if(parryLevel == "critical")
        {
            criticalClashSound.Play();
        }
    }
}
