﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Value = 100;
    public RectTransform ValueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxValue;

    private void Start()
    {
        _maxValue = Value;
        DrawHealthBar();
    }
    public void DealDamage(float damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        Value += amount;
        Value = Mathf.Clamp(Value, 0, _maxValue);
        DrawHealthBar();
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<PlayerShooting>().enabled = false;
        GetComponent<GrenadeCaster>().enabled = false;
        gameOverScreen.GetComponent<Animator>().SetTrigger("GameOver");
    }

    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Value / _maxValue, 1);
    }

    public bool IsAlive()
    {
        return Value > 0;
    }
}
