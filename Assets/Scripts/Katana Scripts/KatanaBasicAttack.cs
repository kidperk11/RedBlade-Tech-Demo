using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaBasicAttack : MonoBehaviour
{
    public int katanaDamage;
    public ChargeBlade chargeBlade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object has entered the Katana Trigger box: " + other.tag);

        if (other.CompareTag("Enemy"))
        {
            if (chargeBlade.attackReady)
            {
                EnemyHealth healthInstance = other.gameObject.GetComponentInParent<EnemyHealth>();
                healthInstance.TakeDamage(katanaDamage);
                chargeBlade.attackReady = false;
                chargeBlade.timerForCharge = 0;
                chargeBlade.bladeMaterial.color = chargeBlade.defaultColor;
            }
        }
        if(other.CompareTag("Critical Hit Point"))
        {
                CriticalHitPoint critPoint = other.gameObject.GetComponent<CriticalHitPoint>();
                critPoint.mainBodyHealth.isCriticalDead = true;
                chargeBlade.attackReady = false;
                chargeBlade.bladeMaterial.color = chargeBlade.defaultColor;
                chargeBlade.timerForCharge = 0;
        }
    }
}
