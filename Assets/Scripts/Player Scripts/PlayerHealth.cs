using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject katana;
    public int maxHealth;
    public int currentHealth;
    public AudioSource hurtSound;
    public float currentPosture;
    [SerializeField] private float maxPosture;
    [SerializeField] private float maxPostureBreakTime;
    public float postureBreakTimer;
    public Slider healthBar;
    public Slider postureBar;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.playerHealth = this;
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
        }
        if (postureBar != null)
        {
            postureBar.maxValue = maxPosture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPosture > 0)
        {
            currentPosture -= Time.deltaTime;
        }
        if (postureBreakTimer > 0)
        {
            katana.SetActive(false);
            postureBreakTimer -= Time.deltaTime;
            if(postureBreakTimer <= 0)
            {
                katana.SetActive(true);
            }
        }
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
        if (postureBar != null)
        {
            postureBar.value = currentPosture;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hurtSound.Play();
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
        if(currentPosture >= maxPosture)
        {
            postureBreakTimer = maxPostureBreakTime;
            currentPosture = 0;
        }
    }
}
