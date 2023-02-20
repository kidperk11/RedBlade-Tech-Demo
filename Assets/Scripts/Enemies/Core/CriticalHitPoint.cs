using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CriticalHitPoint : MonoBehaviour
{
    [SerializeField] private float maxCritTime;
    public float critTimer;
    [SerializeField] private float critMaterialAlpha;
    public Material critMaterial;
    public Color critTweenStartColor;
    public Color critTweenEndColor;
    public EnemyHealth mainBodyHealth;

    private void Start()
    {
        critMaterial.DOColor(critTweenEndColor, "_BaseColor", 0.5f).SetLoops(-1, LoopType.Yoyo);
    }
    void OnEnable()
    {
        critTimer = maxCritTime;
        critMaterial.SetColor("_BaseColor", critTweenStartColor);
        
    }

    // Update is called once per frame
    void Update()
    {
        critTimer -= Time.deltaTime;
        if(critTimer <= 0)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
