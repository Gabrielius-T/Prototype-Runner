using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class LifeCollectable : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsController playerStatsController;

    [SerializeField]
    private AudioSource pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerStatsController.AddLife();
        pickupSound.Play();
        Destroy(gameObject);
    }
}
