using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public AudioSource hurtSound;
    public float currentPosture;
    [SerializeField] private float maxPosture;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.playerHealth = this;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            //NOTE: Swap this code when a proper Game/Scene manager is added to 
            //go to a game over screen.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TakePostureDamage(float postureDamage)
    {
        currentPosture += postureDamage;
    }
}
