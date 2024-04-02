using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private RectTransform rt;
    [SerializeField] private Slider slider;
    [SerializeField] private CharacterStats myStats;

    private void OnEnable()
    {
        entity.onFlipped += FlipUI;
        myStats.onHealthChanged += UpdateHealthUI;
    }

    private void Start()
    {
        UpdateHealthUI();
    }

    private void FlipUI()
    {
        rt.Rotate(0f, 180f, 0f);

    }

    private void UpdateHealthUI()
    {
        slider.maxValue = myStats.GetMaxHealthValue();
        slider.value = myStats.currentHealth;
    }

    private void OnDisable()
    {
        entity.onFlipped -= FlipUI;
        myStats.onHealthChanged -= UpdateHealthUI;
    }
}
