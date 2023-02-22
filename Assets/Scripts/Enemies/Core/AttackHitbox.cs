using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    //These bools will be triggered by the animator to indicate how effective the parry was, and determine things like
    //perfect parries and posture damage
    public bool negativeWindow;
    public bool neutralWindow;
    public bool positiveWindow;
    public bool criticalWindow;
    [SerializeField] private bool parryInput;

    public EnemyHealth mainBodyHealth;

    [SerializeField] private float postureDamage;

    //NOTE: Add this variable so that the player can take damage.
    //[SerializeField] private (insert Player Health here) playerHealth;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        if(!parryInput)
        {
            //NOTE: Deduct some health from the player 
            //by referencing the playerHealth variable;
        }
        negativeWindow = false;
        neutralWindow = false;
        positiveWindow = false;
        criticalWindow = false;
        parryInput = false;
        //playerHealth = null;
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
            if (negativeWindow)
            {
                //Return the posture damage back to the player
                //Play sound effects
            }
            else if (neutralWindow)
            {
                //play sound effects
            }
            else if (positiveWindow)
            {
                mainBodyHealth.currentPosture += playerPostureDamage;
                //Return a negative int to take posture damage off of the player
                //play sound effects
            }
            else if (criticalWindow)
            {
                //Return a bigger negative int to take posture damage off of the player;
                //play sound effects
                mainBodyHealth.criticalParryOpening = true;
            }
        }
        
    }
}
