using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool invincible;
    public bool criticalParryOpening;
    public List<GameObject> shieldObjects;
    public bool isDead;
    public bool isCriticalDead;
    public EnemyHealth parentHealth;
    public AudioSource hurtSound;

    public Transform canvasTransform;
    public Transform camTransform;
    public Slider healthBar;
    public Slider postureBar;

    public float currentPosture;
    [SerializeField] private float maxPosture;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        camTransform = Camera.main.transform;
        Debug.Log("Camera Transform: " + camTransform);
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
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
        if(postureBar != null)
        {
            postureBar.value = currentPosture;
        }
        if (currentPosture > 0)
        {
            if(currentPosture >= maxPosture)
            {
                criticalParryOpening = true;
                currentPosture = 0;
            }
            else
            {
                currentPosture -= Time.deltaTime;
            }
        }
    }

    private void LateUpdate()
    {
        if (canvasTransform != null)
        {
            canvasTransform.LookAt(canvasTransform.position + camTransform.forward);
        }
    }

    public void TakeDamage(int damage, float postureDamage)
    {
        if(shieldObjects.Count == 0 && !criticalParryOpening)
        {
            currentHealth -= damage;
            if (postureBar != null)
            {
                currentPosture += postureDamage;
            }
            if(hurtSound != null)
            {
                hurtSound.Play();
            }
            if (currentHealth <= 0)
            {
                
                if(parentHealth != null)
                {
                    parentHealth.shieldObjects.Remove(this.gameObject);
                    //if(parentHealth.shieldObjects.Count <= 0)
                    //{
                    //    parentHealth.criticalParryOpening = true;
                    //}
                }
                isDead = true;
            }
            //if(postureDamage >= maxPosture)
            //{
            //    criticalParryOpening = true;
            //}
        }
    }
}
