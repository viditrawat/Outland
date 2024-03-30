using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer; 
    [Header("Flash Fx")]
    [SerializeField] private Material hitMat;
    private Material originalMat;

    private void Start()
    {
        originalMat = spriteRenderer.material;
    }

    public IEnumerator FlashFX()
    {
        spriteRenderer.material = hitMat;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.material = originalMat;
    }
}
