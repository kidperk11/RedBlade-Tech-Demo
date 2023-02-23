using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner;

public class AttackHitbox : MonoBehaviour
{
    //These bools will be triggered by the animator to indicate how effective the parry was, and determine things like
    //perfect parries and posture damage
    public bool failureWindow;
    public bool negativeWindow;
    public bool neutralWindow;
    public bool positiveWindow;
    public bool criticalWindow;

    [SerializeField] private bool parryInput;

    public EnemyHealth mainBodyHealth;

    [SerializeField] private float postureDamage;
    [SerializeField] private int attackDamage;

    [SerializeField] private AudioSource negativeClashSound;
    [SerializeField] private AudioSource neutralClashSound;
    [SerializeField] private AudioSource positiveClashSound;
    [SerializeField] private AudioSource criticalClashSound;

    [SerializeField] private float positivePostureBonus;
    [SerializeField] private float criticalPostureBonus;

    //NOTE: Add this variable so that the player can take damage.
    public PlayerHealth playerHealth;
    public KatanaParry katanaInstance;
    

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        if(!parryInput)
        {
            GameManager.playerHealth.TakeDamage(attackDamage);
        }
        negativeWindow = false;
        neutralWindow = false;
        positiveWindow = false;
        criticalWindow = false;
        parryInput = false;
        playerHealth = null;
        if (katanaInstance != null)
        {
            katanaInstance.attackHitbox = null;
            katanaInstance = null;
        }
    }

    //NOTE: change the void return to an int so that you can send data back
    //to the player, like how much posture damage the player has taken.
    //Also, add a parameter for the player's health script, so that 
    //this hitbox can damage the player if they don't input a parry.
    public void CheckParry(float playerPostureDamage)
    {
        if (!parryInput)
        {
            parryInput = true;
            if (failureWindow)
            {
                GameManager.playerHealth.TakeDamage(attackDamage);
            }
            if (negativeWindow)
            {
                GameManager.playerHealth.TakePostureDamage(postureDamage);
                //katanaInstance.PlayParrySound("negative");

                //Return the posture damage back to the player
                //Play sound effects
                if (negativeClashSound != null)
                {
                    negativeClashSound.Play();
                }
            }
            else if (neutralWindow)
            {
                //katanaInstance.PlayParrySound("neutral");

                //play sound effects
                if (neutralClashSound != null)
                {
                    neutralClashSound.Play();
                }
            }
            else if (positiveWindow)
            {
                mainBodyHealth.currentPosture += playerPostureDamage;
                //katanaInstance.PlayParrySound("positive");

                GameManager.playerHealth.TakePostureDamage(positivePostureBonus);
                //Return a negative int to take posture damage off of the player
                //play sound effects
                if (positiveClashSound != null)
                {
                    positiveClashSound.Play();
                }
            }
            else if (criticalWindow)
            {
                //katanaInstance.PlayParrySound("critical");
                GameManager.playerHealth.TakePostureDamage(criticalPostureBonus);
                if (criticalClashSound != null)
                {
                    criticalClashSound.Play();
                }
                //Return a bigger negative int to take posture damage off of the player;
                //play sound effects
                mainBodyHealth.criticalParryOpening = true;
            }
        }
        
    }
}
