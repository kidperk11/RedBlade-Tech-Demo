using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonShield : MonoBehaviour
{
    public EnemyHealth shieldHealth;
    public MeshExploder exploder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHealth.isDead)
        {
            StartCoroutine(BlowUp());
        }
    }

    IEnumerator BlowUp()
    {
        //exploder.Explode();
        Destroy(this.gameObject);
        return null;
    }
}
