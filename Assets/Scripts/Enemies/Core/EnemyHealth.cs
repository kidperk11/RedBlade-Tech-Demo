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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldObjects.Count > 0)
        {
            foreach(GameObject shield in shieldObjects)
            {
                if(shield == null)
                {
                    shieldObjects.Remove(shield);
                }
            }
            if (shieldObjects.Count <= 0)
            {
                criticalParryOpening = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if(shieldObjects.Count == 0)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                isDead = true;
            }
        }
    }
}
