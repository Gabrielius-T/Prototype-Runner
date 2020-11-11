﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CoinsCollectable : MonoBehaviour
{
    [SerializeField] int coinsAmount;

    AudioSource pickupSound;
    
    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D _collision)
    {
        PlayerStatsController.instance.AddMoney(coinsAmount);
        pickupSound.Play();
        Destroy(gameObject);
    }
}
