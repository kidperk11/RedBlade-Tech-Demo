using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float currentPosture;
    [SerializeField] private float maxPosture;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPosture > 0)
        {
            if(currentPosture >= maxPosture)
            {
                criticalParryOpening = true;
            }
            else
            {
                currentPosture -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if(shieldObjects.Count == 0)
        {
            currentHealth -= damage;
            if(hurtSound != null)
            {
                hurtSound.Play();
            }
            if(currentHealth <= 0)
            {
                if(parentHealth != null)
                {
                    parentHealth.shieldObjects.Remove(this.gameObject);
                    if(parentHealth.shieldObjects.Count <= 0)
                    {
                        parentHealth.criticalParryOpening = true;
                    }
                }
                isDead = true;
            }
        }
    }
}
